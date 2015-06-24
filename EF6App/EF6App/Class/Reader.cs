using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.Data.SqlClient;

namespace EF6App
{
    public class Reader
    {
        public delegate void ReaderEventHandler(string msg);

        private char[] delimiters = new char[] { ',', ';' };
        private char[] delimitersFileCSV = new char[] { '_', '\\' };
        
        public void ReadFileAndAddToDb(String filename, ReaderEventHandler handler)
        {
            try
            {
                //string[] fileNameParce = filename.Split(delimitersFileCSV);
                //Console.WriteLine(fileNameParce[2]);
                if (CheckAlreadyParsed(filename))
                {
                    handler("Already parsed");
                    //DeleteDuplicate();

                    ReadFile(filename, handler);

                    SaveProcessedFileInfo(filename);

                    MoveFileToArchive(filename);
                }
                else
                {
                    handler("The file is already loaded!");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        private bool CheckAlreadyParsed (string filename)
        {
            using (LoadingFileContext dbLoadingFileContext = new LoadingFileContext())
            {
                var countFileName =
                    dbLoadingFileContext.LoadingFiles.Where(p => p.FileName == GetFileName(filename)).Count();
                if (countFileName > 0)
                    return false;
            }
            return true;
        }

        private string GetFileName(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string fileName = fileInf.Name;
            return fileName;
        }

        private void MoveFileToArchive(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string name = GetFileName(filename);
            fileInf.MoveTo(Constants.TargetPath + '\\' + name);
        }

        private void ReadFile(string filename, ReaderEventHandler handler)
        {
            using (StreamReader rd = new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while (rd.Peek() >= 0)
                {
                    try
                    {
                        string line = rd.ReadLine();
                        string[] vals = line.Split(delimiters);

                        SaveSaleInfo(handler, vals);
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine("Error adding of data from {0}. Message = {1}", filename, e.Message);
                    }
                    finally
                    {
                        if (rd != null)
                        {
                            rd.Close();
                        }
                    }
                }
            }
        }

        private void SaveSaleInfo(ReaderEventHandler handler, string[] vals)
        {
            using (ManagerSaleContext db = new ManagerSaleContext())
            {
                Console.WriteLine(vals[0]);
                ManagerSale client1 = new ManagerSale
                {
                    ManagerSurname = vals[0],
                    ManagerDate = DateTime.Parse(vals[1]),
                    ClientDate = DateTime.Parse(vals[2]),
                    Client = vals[3],
                    Product = vals[4],
                    Sum = Convert.ToInt32(vals[5])
                };

                if (DbConnectionStatus())
                {
                    db.ManagerSales.Add(client1);
                    db.SaveChanges();
                }
                else
                {
                    handler("connection error");
                }
            }
        }

        private void SaveProcessedFileInfo(string filename)
        {
            using (LoadingFileContext dbLoadingFileContext = new LoadingFileContext())
            {
                FileInfo fileInf = new FileInfo(filename);
                LoadingFile loadingFile = new LoadingFile
                {
                    FileName = fileInf.Name,
                    CreationDate = fileInf.CreationTime,
                    FileLenght = fileInf.Length,
                };

                dbLoadingFileContext.LoadingFiles.Add(loadingFile);
                dbLoadingFileContext.SaveChanges();
            }
        }

        private static bool DbConnectionStatus()
        {
            try
            {
                using (SqlConnection sqlConn =
                        new SqlConnection("data source=HOME-nout;Initial Catalog=manager.mdf;Integrated Security=True;"))
                {
                    sqlConn.Open();
                    return (sqlConn.State == ConnectionState.Open);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false; 
            }
        }
    }
}