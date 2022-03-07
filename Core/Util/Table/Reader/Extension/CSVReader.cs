using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Core.Util.Table.Reader.Extension
{
    public class CSVReader : Reader
    {
        public CSVReader( string _strName, SetDataFunction _setDataDelegate, SetColumnFunction _setColumnDelegate, Dictionary<EReadOptionType, bool> _dicOption )
            : base( _strName, _setDataDelegate, _setColumnDelegate, _dicOption )
        {

        }

        public override bool OnParser()
        {
            bool isComplete = false;
            StreamReader streamReader = null;
            try
            {
                FileStream streamFile = new FileStream(GetFileAddress(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if( null == streamFile )
                    throw new Exception( "FileStream is Null" );

                streamReader = new StreamReader( streamFile, Encoding.Default );

                string strLine      = "";
                string[] arrValues  = null;
                string[] arrRowKey  = null;
                int rowCount        = 0;

                while( !streamReader.EndOfStream )
                {
                    ++rowCount;
                    strLine = streamReader.ReadLine();
                    arrValues = strLine.Split('\t', ';');

                    if( 1 == rowCount )
                    {
                        arrRowKey = arrValues;
                        SetRowKeyDataList( arrRowKey );
                        continue;
                    }

                    int errorCount = arrValues.Length;
                    for( int i = 0; i < arrValues.Length; ++i )
                    {
                        if( false == SetRowValueData( arrRowKey[i], arrValues[i] == "" ? "-1" : arrValues[i] ) )
                            --errorCount;
                    }

                    if( 0 == errorCount )
                    {
                        ErrorMessage( string.Format( "Template value is empty string FileName: {0}", FileName ) );
                        break;
                    }

                    ProcessCallbackFunction();
                }

                isComplete = true;
            }
            catch( Exception ex )
            {
                ErrorMessage( ex.Message );
            }
            finally
            {
                if( null != streamReader )
                    streamReader.Close();
            }

            return isComplete;
        }
    }
}
