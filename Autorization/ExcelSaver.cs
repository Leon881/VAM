using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Autorization_form;
using Dapper;

namespace Multiplector.Autorization
{
    public class ExcelSaver
    {     
        public static void AddUsersToSheet()
        {
            Excel.Application exApp = new Excel.Application
            {
                Visible = true
            };

            exApp.SheetsInNewWorkbook = 1;
            exApp.Workbooks.Add();
            Excel.Worksheet exWrkSheet = exApp.Workbooks[1].Worksheets.get_Item(1);
            exWrkSheet.get_Range("A1", "A1").Value = "Login";
            exWrkSheet.get_Range("B1", "B1").Value = "HashPass";

            var usersList = SqlDataAccess.GetUsers();


            for (int i = 2; i < usersList.Count + 2; i++)
            {
                var letter = 'A';
                exWrkSheet.get_Range(letter.ToString() + i, letter.ToString() + i).Value = usersList[i - 2].Login;
                letter = Convert.ToChar(letter + 1);
                exWrkSheet.get_Range(letter.ToString() + i, letter.ToString() + i).Value = usersList[i - 2].HashPass;
            }

            exApp.Workbooks[1].SaveAs(Environment.CurrentDirectory + "\\Autorization\\Users.xlsx");
        }
    }
}
