using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace ClientForm.Common
{
	public static partial class Helper
	{
        public const bool TestDataSetting = false;
		private static List<string> m_liComboxBoxTitle = new List<string>();

		private static string GetComboBoxKey(ComboBox comboBox)
		{
			return $"{comboBox.TopLevelControl.Name}_{comboBox.Name}";
		}

        private static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (null == comboBox)
                return;

            e.DrawBackground(); // Always draw the background.               
            if (0 > e.Index) // If there are items to be drawn.
                return;

            StringFormat format = new StringFormat(); // Set the string alignment.  Choices are Center, Near and Far.
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings.
            // Assumes Brush is solid.
            Brush brush = new SolidBrush(comboBox.ForeColor);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) // If drawing highlighted selection, change brush.
            {
                brush = SystemBrushes.HighlightText;
            }
            e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, brush, e.Bounds, format); // Draw the string
        }

        public static void SetController(ref ComboBox comboBox, string strTitle, string[] items, int selectedIdx = 0)
		{
			if (null == comboBox)
				return;

			comboBox.Items.Clear();
			if (false == string.IsNullOrEmpty(strTitle))
			{
				comboBox.Items.Add(strTitle);
                SetComboBoxTitle(comboBox);
            }

			comboBox.Items.AddRange(items);
            SetComboBoxStyle(ref comboBox, selectedIdx);
        }

        public static void SetComboBoxStyle(ref ComboBox comboBox, int selectedIdx)
		{
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            if (selectedIdx >= comboBox.Items.Count)
                return;

            comboBox.SelectedIndex = selectedIdx;
        }

        public static void SetComboBoxTitle(ComboBox comboBox)
		{
            string strKey = GetComboBoxKey(comboBox);
            if (true == m_liComboxBoxTitle.Contains(strKey))
                return;

            m_liComboxBoxTitle.Add(GetComboBoxKey(comboBox));
        }

        public static void SetComboBox(ref ComboBox comboBox, string strText)
        {
            var index = comboBox.Items.IndexOf(strText);
            if (0 > index)
                return;

            comboBox.SelectedIndex = index;
        }

        public static void OpenForm(Form form)
        {
            if (string.IsNullOrEmpty(form.Name))
                return;

            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name != form.Name)
                    continue;

                openForm.Activate();
                return;
            }

            form.Show();
        }

        public static bool ContainsTitle(ComboBox comboBox)
		{
            if (0 != comboBox.SelectedIndex)
                return false;

            var comboBoxKey = GetComboBoxKey(comboBox);
            return m_liComboxBoxTitle.Contains(comboBoxKey);
		}

        public static bool RemoveTitle(ref ComboBox comboBox)
		{
			if (null == comboBox)
				return false;

			string comboBoxKey = GetComboBoxKey(comboBox);
			int index = m_liComboxBoxTitle.FindIndex(x => x.Contains(comboBoxKey));
			if (0 > index || 0 == comboBox.SelectedIndex)
				return false;

			m_liComboxBoxTitle.RemoveAt(index);
			comboBox.Items.RemoveAt(0);
            return true;
		}

        public static void SetListControlKeyValueData(ListControl lc, DataTable dt, List<DataColumn> liColumn)
		{
            if (2 > liColumn.Count)
            {
                Log.ErrorLog($"SetListControlKeyValueData. Control:{lc.Name}");
                return;
            }

            dt.TableName = lc.Name;
            foreach (var column in liColumn)
                dt.Columns.Add(column);

            lc.DisplayMember = liColumn[0].ColumnName;
            lc.ValueMember = liColumn[1].ColumnName;
            lc.DataSource = dt;
        }

        public static bool EmptyTextBox(params TextBox[] _arrTextBox)
        {
            foreach (var tb in _arrTextBox)
            {
                if (true == string.IsNullOrEmpty(tb.Text))
                    return true;
            }

            return false;
        }

        #region DataRow helper
        public static void InsertDateRow(DataTable dt, string key, object value)
        {
            DataRow row = dt.NewRow();
            row[0] = key;
            row[1] = value;

            dt.Rows.Add(row);
        }

        public static DataRow GetDataRow(DataTable dt, string key)
		{
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == key)
                    return row;
            }

            return null;
        }
        #endregion

        #region control method
        public static void SetEnable(Control control, bool enable)
        {
            ControlUpdate(control, () =>
            {
                control.Enabled = enable;
            });
        }

        public static void FocusHandle(Control control, string strMessage)
        {
            MessageBox.Show(strMessage);
            if (null != control)
                control.Focus();
        }

        public static void ControlUpdate(Control control, Action action)
        {
            control?.Invoke((MethodInvoker)delegate
            {
                action.Invoke();
            });
        }
        #endregion
    }
}
