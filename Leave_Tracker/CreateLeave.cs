using System;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace LeaveTracker
{

    public class CreateLeave
    {
        public void Leave(int id, Writer w, string file_path)
        { 
            try{
                string title="";
                string description ="";
                string startDate;
                string endDate;
            
                System.Console.Write("Please enter Title : ");
                title=Console.ReadLine();

                System.Console.Write("Please enter Description : ");
                description=Console.ReadLine();

                System.Console.Write("Please enter Start Date : ");
                startDate=Console.ReadLine();

                System.Console.Write("Please enter End Date : ");
                endDate=Console.ReadLine();

                ReadData(w, file_path, id, title, description, startDate, endDate);

            } 
            catch(Exception)
            {
            System.Console.WriteLine("Error occured"); 
            }
        }

        private void ReadData(Writer w,string file_path, int id, string title, string description, string startDate, string endDate)
        {
            try{
                
            var csvTable = new DataTable();
            
            string path=@"C:\Users\shriyab\Downloads/employees.csv";
            

            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true))  
            {  
                int i;
                string creatorName="";
                string managerName="";
                string managerId="";

                csvTable.Load(csvReader);

                for(i=0;i<csvTable.Rows.Count;i++)
                {
                    string row=csvTable.Rows[i][0].ToString();
                    
                        if(id.ToString().Equals(csvTable.Rows[i][0].ToString())){
                            creatorName=csvTable.Rows[i][1].ToString();
                            managerId=csvTable.Rows[i][2].ToString();            
                        }
                    
                }

                for(i=0;i<csvTable.Rows.Count;i++){
                    if(managerId.Equals(csvTable.Rows[i][0].ToString())){
                        managerName=csvTable.Rows[i][1].ToString();
                    }
                }

                w.WriteToCSV(id, creatorName,managerName, title, description, startDate, endDate, file_path);

            }     
        }
        catch(Exception)
        {
            System.Console.WriteLine("Error Occured");
        }
        }
    }

}