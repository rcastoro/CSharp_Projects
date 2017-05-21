using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using System.Text;
using System.IO;

namespace TimesheetService
{
    public class ExcelFunctionality
    {

        string _file;
        Timesheet.Timesheet _ts = new Timesheet.Timesheet();
        List<Worksheet> worksheets;
        Workbook workbook;
        int _worksheetCount = 0;

        public int WorksheetCount
        {
            get
            {
                return _worksheetCount;
            }
            set
            {
                _worksheetCount = value;
            }
        }


        public ExcelFunctionality()
        {

        }

        public void CreateWorkbook(Timesheet.Timesheet ts, string filetitle, int qtyWorksheets)
        {
            _ts = ts;

            //create new xls file
            _file = filetitle + ".xls";
            workbook = new Workbook();
            worksheets = new List<Worksheet>();

            for (int i = 1; i <= qtyWorksheets; i++)
            {
                worksheets.Add(new Worksheet("Worksheet"+i));
            }

            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    worksheets[0].Cells[i+10, j+10] = new Cell(" ");
                }
            }
        }

        public void SetWorksheetHeader(int worksheetNumber, string header)
        {
            worksheets[worksheetNumber].Cells[0, 0] = new Cell((string)header);
        }

        public void AddCellToWorksheet(int worksheetNumber, int row, int col, string data)
        {
            worksheets[worksheetNumber].Cells[row, col] = new Cell((string)data);
        }

        public void AddTimesheet(Timesheet.Timesheet ts)
        {
            int i = 2;
            DateTime dtFrom = new DateTime();
            DateTime dtTo = new DateTime();
            DateTime date = new DateTime();
            foreach (Timesheet.Day day in ts.days)
            {
                date = DateTime.Parse(day.date.ToString());
                dtFrom = DateTime.Parse(day.hours[0].start);
                dtTo = DateTime.Parse(day.hours[0].end);

                AddCellToWorksheet(0, i, 0, date.ToString("MM/dd/yyyy"));
                AddCellToWorksheet(0, i, 1, dtFrom.ToString("hh:mm tt"));
                AddCellToWorksheet(0, i, 2, dtTo.ToString("hh:mm tt"));
                AddCellToWorksheet(0, i, 3, day.hours[0].lunch.ToString());
                AddCellToWorksheet(0, i, 4, day.hours[0].hours.ToString());
                i++;
            }
            AddCellToWorksheet(0, i + 2, 3, "Total:");
            AddCellToWorksheet(0, i + 2, 4, _ts.totalhours.ToString());
        }

        public string SaveWorkbook()
        {
            string path = @"C:\Dump\";

            foreach (Worksheet worksheet in worksheets)
            {
                workbook.Worksheets.Add(worksheet);
            }

            workbook.Save(path+_file);
            return _file;
        }
    }
}