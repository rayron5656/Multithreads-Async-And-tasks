using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Threads_HW
{
    
        


        
        public class Search
        {

            public string SearchTerm { get; set; }
            public string Drive { get; set; }
            public IList FilesFound { get; set; } = ArrayList.Synchronized(new List<string>());
            IList tasks = ArrayList.Synchronized(new List<Task>());
            public bool CanContinue { get; set; }

        public Search(string searchTerm, string drive)
            {
                SearchTerm = searchTerm;
                Drive = drive;
                CanContinue = true;
            }

        public void Stop()
        {
            CanContinue = false;
            foreach (Task T in tasks)
            {
                T.Dispose();
            }
            
            
        }

        

            public async Task ProccessDirectory(string directoryPath)
            {
                try
                {
                    if (CanContinue)
                    {
                        Task t1 = Task.Run(() =>
                        {
                            List<string> directories = new List<string>();
                            try
                            {
                                directories = Directory.GetDirectories(directoryPath).ToList();
                                Parallel.ForEach(directories, (directory, ct) => { ProccessDirectory(directory); });
                            }
                            catch (System.UnauthorizedAccessException ex) { }

                            try
                            {
                                var fileNames = Directory.GetFiles(directoryPath);
                                Parallel.ForEach(fileNames, (file, ct) => ProccessFile(file));
                            }
                            catch (System.UnauthorizedAccessException ex) { }
                        });

                        
                    }
                    else
                    {
                        
                    }
                    


                    

                    //Task.WaitAll(t1);

                }
                catch (UnauthorizedAccessException)
                {

                }


            }

            private void ProccessFile(string fileName)
            {
            try
            {

                if (Path.GetExtension(fileName) == ".txt")
                {
                    string content = "";
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        try
                        {
                            content = sr.ReadToEnd();
                            if (content.Contains(SearchTerm))
                            {
                                FilesFound.Add(fileName);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
            }
            catch (Exception)
            {

                
            }


            }
        }




        

    
    
}
