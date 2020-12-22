using System;
using System.IO;
//using System.IO.FileInfo;
using System.Linq;

namespace LeaveTracker
{
    public class Writer
    {

        public Writer(string file_path)
        {
            if(!(File.Exists(file_path))){
                string headings = "Id,Creator,Manager,Title,Description,Start Date,End Date,Status" + Environment.NewLine;
                File.WriteAllText(file_path,headings);
            }

        }


        public void WriteToCSV(int id,string creatorName, string managerName, string title, string description, string startDate, string endDate, string file_path)
        {
            try{
                string text = id+","+creatorName+","+managerName +","+title +","+description+","+startDate +","+ endDate+","+"Pending";
                File.AppendAllText(file_path,text);
                File.AppendAllText(file_path, "\n");

            }
            catch(Exception)
            {
                System.Console.WriteLine("File Appending failed");
            }
        }
    }
}