using System;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Chilkat;


namespace LeaveTracker
{
    public class SearchLeaves{
        public void Search(int id, string file_path)
        {
            int option;
            System.Console.Write("1.Search by Title        2.Search by Status");
            System.Console.Write("\nPlease enter your choice : ");
            option=Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                searchByTitle(id,file_path);
                break;

                case 2:
                searchByStatus(id,file_path);
                break;

                default:
                
                break;
            }
        }

        private void searchByStatus(int id,string leaves_path)
        {
            try{
                string status = "";
            
            System.Console.Write("Please enter the status to search : ");
            status=Console.ReadLine();


            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(leaves_path)), true))  
                {  
                    int i;
                    var lvsTable = new DataTable();
                    
                    lvsTable.Load(csvReader);

                    for(i=0;i<lvsTable.Rows.Count;i++)
                    {
                        string row=lvsTable.Rows[i][0].ToString();
                    
                            if(id.ToString().Equals(lvsTable.Rows[i][0].ToString()) && (status==(lvsTable.Rows[i][7]).ToString())){
                                System.Console.WriteLine("Title, Description, Start date, End date, Status : "+lvsTable.Rows[i][3]+"\t"+lvsTable.Rows[i][4]
                                +"\t"+lvsTable.Rows[i][5]+"\t"+lvsTable.Rows[i][6]+"\t"+lvsTable.Rows[i][7]);

                            }
                    }
                }


            }
            catch(Exception)
            {
                System.Console.WriteLine("Error occured");
            }
            
        }

        private void searchByTitle(int id,string leaves_path)
        {
            try{
                string title = "";
            
            System.Console.Write("Please enter the title to search : ");
            title=Console.ReadLine();


            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(leaves_path)), true))  
                {  
                    int i;
                    var lvsTable = new DataTable();
                    
                    lvsTable.Load(csvReader);

                    for(i=0;i<lvsTable.Rows.Count;i++)
                    {
                        string row=lvsTable.Rows[i][0].ToString();
                    
                            if(id.ToString().Equals(lvsTable.Rows[i][0].ToString()) && (title==(lvsTable.Rows[i][3]).ToString())){
                                System.Console.WriteLine("Title, Description, Start date, End date, Status : "+lvsTable.Rows[i][3]+"\t"+lvsTable.Rows[i][4]
                                +"\t"+lvsTable.Rows[i][5]+"\t"+lvsTable.Rows[i][6]+"\t"+lvsTable.Rows[i][7]);

                            }
                    }
                }

            }
            catch(Exception)
            {
                System.Console.WriteLine("Error occured");
            }
            

        }
    }
}