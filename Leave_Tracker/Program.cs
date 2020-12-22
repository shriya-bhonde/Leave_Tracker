using System;
using System.IO;


namespace LeaveTracker
{
    class Program
    {
        static string file_path="";
        private void pathGetter()
        {
            try{
                r:System.Console.Write("Please enter the path to CSV File : ");
                file_path=Console.ReadLine();

                FileInfo fi = new FileInfo(file_path);
                string extn="";
                string fileName = fi.Extension;

                if(extn!=".csv")
                {
                    System.Console.WriteLine("Invalid File Extension");
                    goto r;
                }
            }catch(Exception)
            {
                System.Console.WriteLine("Error Occured");
            }
            
            

        }
        static void Main(string[] args)
        {
            int id;
            bool valid;
            try{
                do{
                Console.Write("Please enter Employee ID : ");
                id = Convert.ToInt32(Console.ReadLine());

                if(id<100 || id>110)
                {
                    System.Console.WriteLine("Incorrect Employee ID");
                    valid = false;
                }
                else{
                    valid = true;
                }
                }while(valid==false);

                Writer w = new Writer(file_path);

                new Program().pathGetter();

                int choice;
                System.Console.WriteLine("1.Create Leave     2.List Leaves      3.Update Leaves       4.Search Leaves       5.Exit");
                System.Console.Write("Please enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
            
            
                while(choice!=5){
        
                switch(choice)
                {
                    case 1:
                        //call to CreateLeave()
                        CreateLeave cl = new CreateLeave();
                        cl.Leave(id,w,file_path);
                        break;
                
                    case 2:
                        //call to ListLeaves()
                        ListLeaves ll = new ListLeaves();
                        ll.List(id,file_path);
                        break;

                    case 3:
                        //call to UpdateLeaves()
                        UpdateLeaves ul = new UpdateLeaves();
                        ul.Update(id,file_path);
                        break;

                    case 4:
                        //Call to SearchLeaves()
                        SearchLeaves sl = new SearchLeaves();
                        sl.Search(id,file_path);
                        break;

                    default:
                        System.Console.WriteLine("Invalid Choice");
                        break;
                }

                System.Console.WriteLine("1.Create Leave     2.List Leaves      3.Update Leaves       4.Search Leaves       5.Exit");
                System.Console.Write("Please enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
            
                }//end of while
            
            }
            catch(Exception)
            {
                System.Console.WriteLine("Error occured");
            }
        }
            
    }
}
