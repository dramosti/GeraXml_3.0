using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;

namespace HLP.GeraXml.Comum
{
    public class belIsolated
    {
        public enum Lugar { Local, Maquina };

        IsolatedStorageFile armazenamento;
        IsolatedStorageFileStream arqFileStream;

        /// <summary>
        /// Verifica se o arquivo existe;
        /// </summary>
        /// <param name="sNomeArquivo">Nome do Arquivo com a Extensão - Exemplo: UserSettings.diego</param>
        /// <param name="_onde">Local</param>
        /// <returns></returns>
        public bool Existe(string sNomeArquivo, Lugar _onde)
        {
            InstanciaIsolatedStorageFileBusca(_onde);

            string[] files = armazenamento.GetFileNames(sNomeArquivo);

            if (files.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteArquivo(string sNomeArquivo, Lugar _onde)
        {
            InstanciaIsolatedStorageFileBusca(_onde);

            string[] files = armazenamento.GetFileNames(sNomeArquivo);

            if (files.Count() > 0)
            {
                armazenamento.DeleteFile(sNomeArquivo);
            }
        }

        public void SalvarArquivo(string sNomeArquivo, string TextArquivo, Lugar _onde)
        {
            InstanciaIsolatedStorageFileBusca(_onde);
            arqFileStream = new IsolatedStorageFileStream(sNomeArquivo, FileMode.Create, armazenamento);
            StreamWriter userWriter = new StreamWriter(arqFileStream);
            userWriter.Write(TextArquivo);
            userWriter.Close();
            arqFileStream.Close();
        }

        public string BuscarArquivo(string sNomeArquivo, Lugar _onde)
        {
            try
            {
                InstanciaIsolatedStorageFileBusca(_onde);
                string sRetorno = "";
                string[] files = armazenamento.GetFileNames(sNomeArquivo);

                if (files.Count() > 0)
                {
                    arqFileStream = new IsolatedStorageFileStream(sNomeArquivo, FileMode.Open, armazenamento);
                    StreamReader userReader = new StreamReader(arqFileStream);
                    sRetorno = userReader.ReadToEnd();
                    userReader.Close();
                }
                return sRetorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string BuscarLocalArquivo(string sNomeArquivo, Lugar _onde)
        {
            try
            {
                InstanciaIsolatedStorageFileBusca(_onde);
                string sRetorno = "";
                string[] files = armazenamento.GetFileNames(sNomeArquivo);
                if (files.Count() > 0)
                {
                    arqFileStream = new IsolatedStorageFileStream(sNomeArquivo, FileMode.Open, armazenamento);
                    sRetorno = arqFileStream.GetType().GetField("m_FullPath", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(arqFileStream).ToString();
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void InstanciaIsolatedStorageFileBusca(Lugar onde)
        {
            try
            {

                if (onde.ToString().Equals("Local"))
                {
                    armazenamento = IsolatedStorageFile.GetUserStoreForApplication();
                }
                else if (onde.ToString().Equals("Maquina"))
                {
                    armazenamento = IsolatedStorageFile.GetMachineStoreForApplication();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
