using System;
using System.Runtime.CompilerServices;
using NLog;

namespace Core
{
    public enum LogLevel
    {
        /// <summary>
        /// 디버깅 용도로 사용하세요. 
        /// 실제 서비스(개발 서버, 라이브 서버)에서는 로그가 수집되지 않습니다.
        /// </summary>
        Trace,

        /// <summary>
        /// 유저의 특정 행동 로그에 사용하세요. (ex. 아이템 강화 시도 등)
        /// 실제 서비스시에 로그가 수집 됩니다.
        /// </summary>
        Debug,

        /// <summary>
        /// 서버의 상태 등등에 사용하세요.
        /// 실제 서비스시에 로그가 수집 됩니다.
        /// </summary>
        Info,

        /// <summary>
        /// 유저의 특정 행동의 실패에 사용 하세요 (ex. 아이템 강화 시도를 했지만 실패)
        /// 실제 서비스시에 로그가 수집 됩니다.
        /// </summary>
        Warn,

        /// <summary>
        /// 서버 내부의 에러에 대하여 사용하세요 (ex. DB CRUD 실패)
        /// 실제 서비스시에 로그가 수집 됩니다.
        /// </summary>
        Error,

        /// <summary>
        /// 매우 치명적인, 더 이상 서비스가 불가능 한 상태일 때 사용 하세요. (ex. 기획 테이블 오류)
        /// 실제 서비스시에 로그가 수집 됩니다.
        /// </summary>
        Fatal,
    }

    public class Log
	{
        public const string NONE = "NONE";

        static Logger _logger = null;

        /// <summary>
        /// 응용 프로그램으로 주로 사용 될 로거를 설정한다.
        /// </summary>
        /// <param name="yourLoggerName">App 프로젝트의 app.config에 있는 logger 이름을 지정한다.</param>
        static public void InitMainLogger(string yourLoggerName)
        {
            _logger = LogManager.GetLogger(yourLoggerName);
        }

        /// <summary>
        /// 서버의 상태를 남길대 쓰는 메소드
        /// </summary>
        /// <param name="message"></param>
        /// <param name="operation"></param>
        static public void Server(string message, [CallerMemberName] string operation = "")
        {
            Log.Write(LogLevel.Debug, operation, message);
        }

        /// <summary>
        /// Exception 내용을 작성합니다.
        /// </summary>
        /// <param name="level">Exception 내용이 기록 될 수준</param>
        /// <param name="e">Exception 객체</param>
        public static void Write(LogLevel level, Exception e)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    _logger.Trace(e);
                    break;

                case LogLevel.Debug:
                    _logger.Debug(e);
                    break;

                case LogLevel.Info:
                    _logger.Info(e);
                    break;

                case LogLevel.Warn:
                    _logger.Warn(e);
                    break;

                case LogLevel.Error:
                    _logger.Error(e);
                    break;

                case LogLevel.Fatal:
                    _logger.Fatal(e);
                    break;
            }
        }

        /// <summary>
        /// 로그를 작성합니다.
        /// </summary>
        /// <param name="level">로그가 기록 될 수준</param>
        /// <param name="message">로그의 메시지</param>
        public static void Write(LogLevel level, string message)
        {
            if (null == _logger)
                return;

            switch (level)
            {
                case LogLevel.Trace:
                    _logger.Trace(message);
                    break;

                case LogLevel.Debug:
                    _logger.Debug(message);
                    break;

                case LogLevel.Info:
                    _logger.Info(message);
                    break;

                case LogLevel.Warn:
                    _logger.Warn(message);
                    break;

                case LogLevel.Error:
                    _logger.Error(message);
                    break;

                case LogLevel.Fatal:
                    _logger.Fatal(message);
                    break;
            }
        }

        /// <summary>
        /// 로그를 작성합니다.
        /// </summary>
        /// <param name="level">로그가 기록 될 수준</param>
        /// <param name="operation">이 로그의 특정 행동 (ex. api/user/login)</param>
        /// <param name="detail">로그의 메시지</param>
        /// <param name="dataFormat">데이터를 남길 string 포맷</param>
        /// <param name="dataParam">dataFormat에 남길 실제 데이터 오브젝트</param>
        public static void Write(LogLevel level, string operation, string dataFormat, params object[] dataParam)
        {
            Write(level, string.Format("{0}:\"{1}\"", operation, string.Format(dataFormat, dataParam)));
        }

        public static void ErrorLog(string _strMsg)
        {
            Write(LogLevel.Error, _strMsg);
        }

        public static void ErrorLog(string _strFormat, params object[] _arrObj)
        {
            ErrorLog(string.Format(_strFormat, _arrObj));
        }

        public static void InfoLog(string _strFormat, params object[] _arrObj)
        {
            Write(LogLevel.Info, string.Format(_strFormat, _arrObj));
        }

        public static void DebugLog(string _strMsg)
        {
            Write(LogLevel.Debug, _strMsg);
        }

        public static void DebugLog(string _strFormat, params object[] _arrObj)
        {
            DebugLog(string.Format(_strFormat, _arrObj));
        }

        public static void ExceptionLog(Exception ex)
        {
            Write(LogLevel.Error, ex.ToString());
        }
    }
}
