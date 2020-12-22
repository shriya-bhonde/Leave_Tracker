using System;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;


namespace LeaveTracker
{
    public class ListLeaves
    {
        public void List(int id, string file_path)
        {
            try{
                var leavesTable = new DataTable();
            
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(file_path)), true))  
            {  
                int i;
                string startdate="";
                string endDate="";
                string title="";
                string status="";

                leavesTable.Load(csvReader);

                for(i=0;i<leavesTable.Rows.Count;i++)
                {
                    string row=leavesTable.Rows[i][0].ToString();
                    
                        if(id.ToString().Equals(leavesTable.Rows[i][0].ToString())){
                            title=leavesTable.Rows[i][3].ToString();
                            startdate=leavesTable.Rows[i][5].ToString();
                            endDate=leavesTable.Rows[i][6].ToString();
                            status=leavesTable.Rows[i][7].ToString();

                            System.Console.WriteLine("Title, Start Date, End Date, Status: "+title+"\t"+startdate+"\t"+endDate+"\t"+status);            
                        }    
                }

            }
            }
            catch(Exception)
            {
                System.Console.WriteLine("Exception occured");
            }
            
        }//end of List()
    }//end of class
}
