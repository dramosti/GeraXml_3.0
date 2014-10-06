using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Security.Cryptography.Xml;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel
{
    public class belAssinaXml
    {

        private string msgResultado;
        private XmlDocument XMLDoc;

        public XmlDocument XMLDocAssinado
        {
            get { return XMLDoc; }
        }


        public string XMLStringAssinado
        {
            get { return XMLDoc.OuterXml; }
        }

        public string mensagemResultado
        {
            get { return msgResultado; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPathXml"></param>
        /// <param name="sTagBusca"></param>
        /// <param name="cert"></param>
        /// <returns></returns>
        public string ConfigurarArquivo(string sPathXml, string sTagBusca, X509Certificate2 cert)
        {

            string _arquivo = sPathXml;

            if (_arquivo == null)
            {
                Console.WriteLine("\rNome de arquivo não informado...");
            }
            else
            {
                string _uri = sTagBusca;
                if (_uri == null)
                {
                    Console.WriteLine("\rURI não informada...");
                }
                else
                {
                    int resultado = Assinar(sPathXml, _uri, cert);
                    if (resultado == 0)
                    {
                    }
                    else
                    {
                        throw new Exception(mensagemResultado);
                    }
                }
            } 
            return XMLStringAssinado;
        }
        /// <summary>
        /// Gera assinatura Digital do XML
        /// </summary>
        /// <param name="sPathXml"></param>
        /// <param name="RefUri"></param>
        /// <param name="X509Cert"></param>
        /// <returns></returns>
        public int Assinar(string sPathXml, string RefUri, X509Certificate2 X509Cert)
        {


            int resultado = 0;
            msgResultado = "Assinatura realizada com sucesso";
            try
            {
                //   certificado para ser utilizado na assinatura
                //
                string _xnome = "";

                bool bX509Cert = false;

                if (X509Cert != null)
                {
                    _xnome = X509Cert.Subject.ToString();
                }
                else
                {
                    bX509Cert = true;
                }
                X509Certificate2 _X509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, (object)_xnome, true);

                //if (collection1.Count == 0)
                if (bX509Cert)
                {
                    resultado = 2;
                    msgResultado = "Problemas no certificado digital";
                }
                else
                {
                    // certificado ok
                    //_X509Cert = collection1[0];

                    _X509Cert = X509Cert;
                    string x;
                    x = _X509Cert.GetKeyAlgorithm().ToString();
                    // Create a new XML document.

                    XmlDocument doc = new XmlDocument();

                    // Format the document to ignore white spaces.
                    doc.PreserveWhitespace = false;

                    // Load the passed XML file using it's name.
                    try
                    {
                        try
                        {
                            doc.LoadXml(sPathXml);
                        }
                        catch (Exception)
                        {
                            doc.Load(sPathXml);
                        }                       
                        // Verifica se a tag a ser assinada existe é única
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            //  a URI indicada não existe
                            resultado = 4;
                            msgResultado = "A tag de assinatura " + RefUri.Trim() + " inexiste";
                        }
                        // Exsiste mais de uma tag a ser assinada
                        else
                        {

                            if (qtdeRefUri > 1)
                            {
                                // existe mais de uma URI indicada
                                resultado = 5;
                                msgResultado = "A tag de assinatura " + RefUri.Trim() + " não é unica";

                            }
                            else
                            {
                                try
                                {
                                    //Claudinei - o.s. 23615 - 10/08/2009
                                    //for (int i = 0; i < qtdeRefUri; i++)
                                    {
                                        //Fim - Claudinei - o.s. 23615 - 10/08/2009

                                        // Create a SignedXml object.
                                        SignedXml signedXml = new SignedXml(doc);

                                        //sTipoAssinatura = _X509Cert.PrivateKey.KeySize.ToString();
                                        // Add the key to the SignedXml document 
                                        signedXml.SigningKey = _X509Cert.PrivateKey;

                                        // Create a reference to be signed
                                        Reference reference = new Reference();
                                        // pega o uri que deve ser assinada
                                        XmlAttributeCollection _Uri = doc.GetElementsByTagName(RefUri).Item(0).Attributes; //Claudinei - o.s. 23615 - 10/08/2009
                                        foreach (XmlAttribute _atributo in _Uri)
                                        {
                                            if (_atributo.Name == "Id")
                                            {
                                                reference.Uri = "#" + _atributo.InnerText;
                                            }
                                        }
                                        if (reference.Uri == null) { reference.Uri = ""; }

                                        // Add an enveloped transformation to the reference.
                                        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                        reference.AddTransform(env);

                                        XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                        reference.AddTransform(c14);

                                        // Add the reference to the SignedXml object.
                                        signedXml.AddReference(reference);

                                        // Create a new KeyInfo object
                                        KeyInfo keyInfo = new KeyInfo();

                                        // Load the certificate into a KeyInfoX509Data object
                                        // and add it to the KeyInfo object.
                                        keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));

                                        // Add the KeyInfo object to the SignedXml object.
                                        signedXml.KeyInfo = keyInfo;

                                        signedXml.ComputeSignature();

                                        // Get the XML representation of the signature and save
                                        // it to an XmlElement object.
                                        XmlElement xmlDigitalSignature = signedXml.GetXml();
                                        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                        XMLDoc = new XmlDocument();
                                        XMLDoc.PreserveWhitespace = false;
                                        XMLDoc = doc;
                                        if (System.IO.File.Exists(sPathXml))
                                        {
                                            doc.Save(sPathXml);
                                        }
                                    } 
                                }

                                catch (Exception caught)
                                {
                                    resultado = 7;
                                    msgResultado = "Erro: Ao assinar o documento - " + caught.Message;
                                }

                            }
                        }
                    }

                    catch (Exception caught)
                    {
                        resultado = 3;
                        msgResultado = "Erro: XML mal formado - " + caught.Message;
                        GC.Collect();
                    }
                }
            }
            catch (Exception caught)
            {
                resultado = 1;
                msgResultado = "Erro: Problema ao acessar o certificado digital" + caught.Message;
            }

            return resultado;
        }
        public X509Certificate2 BuscaNome(string Nome)
        {
            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, daoUtil.GetDateServidor(), false);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);
                if (Nome == "")
                {
                    X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        Console.WriteLine("Nenhum certificado escolhido", "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                else
                {
                    X509Certificate2Collection scollection = (X509Certificate2Collection)collection2.Find(X509FindType.FindBySubjectDistinguishedName, Nome, false);
                    if (scollection.Count == 0)
                    {
                        Console.WriteLine("Nenhum certificado válido foi encontrado com o nome informado: " + Nome, "Atenção");
                        _X509Cert.Reset();
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                store.Close();
                return _X509Cert;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _X509Cert;
            }
        }
        public X509Certificate2 BuscaNroSerie(string NroSerie)
        {
            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {

                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, daoUtil.GetDateServidor(), true);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection1.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);
                if (NroSerie == "")
                {
                    X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificados Digitais", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        Console.WriteLine("Nenhum certificado válido foi encontrado com o número de série informado: " + NroSerie, "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                else
                {
                    X509Certificate2Collection scollection = (X509Certificate2Collection)collection2.Find(X509FindType.FindBySerialNumber, NroSerie, true);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                        Console.WriteLine("Nenhum certificado válido foi encontrado com o número de série informado: " + NroSerie, "Atenção");
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                store.Close();
                return _X509Cert;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _X509Cert;
            }
        }
    }
}
