using System;
using System.Text;
using System.Runtime.InteropServices;

namespace HLP.GeraXml.bel.NFes.DSF
{
    public class Principal
    {
        string url1;
        string url2;

        // Constructor
        public Principal(string inputString1)
        {
            url1 = inputString1;
            url2 = inputString1 + "?wsdl";
        }



        ////////////////////FUNÇÕES QUE DEVEM SER CHAMADAS ANTES DE QUALQUER DAS ETAPAS : CONSULTAR SEQUÊNCIAL RPS / ENVIAR LOTE / CONSULTAR LOTE / CONSULTAR NOTA.

        //Procedure usada para passar a URL do WebService, deve ser usada antes de qualquer ação de acesso ao webservice.
        [DllImport("lotenfse.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern void setURL(IntPtr varsRPS_HTTPSURL, IntPtr varsRPS_HTTPSWSDL);


        /*
          Função para setar o caminho do arquivo XML a ser gerado.
          Caso queira gravar os XML em arquivos para as funções de Envio de Lote, Consulta de Lote e Consulta de Notas antes de enviar,
          caso não queira gravar, não é necessário fazer chamada a essa função.
        */
        [DllImport("lotenfse.dll")]
        private static extern int setGravaArquivoXML(IntPtr Caminho);



        //////////////////FUNÇÕS CHAMADAS DURANDE O PROCEDIMENTO PARA SE ENTREGAR UM LOTE/////////////////////////////////////////////////
        /*
          OBS: Todas as funções listas abaixo retornam ZERO caso não tenham ocorridos erros internos da DLL ao gerar o lote a ser enviado,
          e caso tenha ocorrido algum erro retorna o código do erro. */

        /* Função para criar o lote de remessa, em cada novo lote de remessa é
          necessário chamar essa função para criar o lote. Onde será enviado os dados do cabeçalho do lote.    */
        [DllImport("lotenfse.dll")]
        private static extern int CriarLote(int CodCidade,
                                         IntPtr CPFCNPJRemetente,
                                         IntPtr RazaoSocialRemetente);

        //Função para passar os dados de cada RPS para a DLL, a ser incluidos no lote
        [DllImport("lotenfse.dll")]
        private static extern int AdicionarRPSV1(IntPtr InscricaoMunicipalPrestador,
                                               IntPtr RazaoSocialPrestador,
                                               IntPtr TipoRPS,
                                               IntPtr SerieRPS,
                                                  int NumeroRPS,
                                               IntPtr DataEmissaoRPS,
                                               IntPtr SituacaoRPS,
                                               IntPtr SerieRPSSubstituido,
                                                  int NumeroRPSSubstituido,
                                                  int NumeroNFSeSubstituida,
                                               IntPtr DataEmissaoNFSeSubstituida,
                                               IntPtr SeriePrestacao,
                                               IntPtr InscricaoMunicipalTomador,
                                               IntPtr CPFCNPJTomador,
                                               IntPtr RazaoSocialTomador,
                                               IntPtr DocTomadorEstrangeiro,
                                               IntPtr TipoLogradouroTomador,
                                               IntPtr LogradouroTomador,
                                               IntPtr NumeroEnderecoTomador,
                                               IntPtr ComplementoTomador,
                                               IntPtr TipoBairroTomador,
                                               IntPtr BairroTomador,
                                                  int CidadeTomador,
                                               IntPtr CidadeTomadorDescricao,
                                               IntPtr CEPTomador,
                                               IntPtr EmailTomador,
                                               IntPtr CodigoAtividade,
                                               double AliquotaAtividade,
                                               IntPtr TipoRecolhimento,
                                                  int MunicipioPrestacao,
                                               IntPtr MunicipioPrestacaoDescricao,
                                               IntPtr Operacao,
                                               IntPtr Tributacao,
                                               double ValorPIS,
                                               double ValorCOFINS,
                                               double ValorINSS,
                                               double ValorIR,
                                               double ValorCSLL,
                                               double AliquotaPIS,
                                               double AliquotaCOFINS,
                                               double AliquotaINSS,
                                               double AliquotaIR,
                                               double AliquotaCSLL,
                                               IntPtr DescricaoRPS,
                                               IntPtr DDDPrestador,
                                               IntPtr TelefonePrestador,
                                               IntPtr DDDTomador,
                                               IntPtr TelefoneTomador,
                                               IntPtr MotCancelamento,
                                               IntPtr CpfCnpjIntermediario);

        //Função para passar os dados de cada item de serviço do RPS
        [DllImport("lotenfse.dll")]
        private static extern int AdicionarItemServicoRPS(IntPtr DiscriminacaoServico,
                                                          double Quantidade,
                                                          double ValorUnitario,
                                                          IntPtr Tributavel);


        //Função para passar os dados de cada item de dedução do RPS
        [DllImport("lotenfse.dll")]
        private static extern int AdicionarDeducaoRPS(IntPtr DeducaoPor,
                                                      IntPtr TipoDeducao,
                                                      IntPtr CPFCNPJReferencia,
                                                         int NumeroNFReferencia,
                                                      double ValorTotalReferencia,
                                                      double PercentualDeduzir,
                                                      double ValorDeduzir);

        /*
           Função para finalizar lote e enviar a remessa. Nesta função a DLL irá gerar o XML de envio e enviar para o WebService,
           O WebService irá determinar se o processamento do lote será Sincrono ou Assincrono. Por padrão o processessmaneto é feito
           assincrono. A função Enviar irá retornar o Numero do Lote gerado. No caso de processamento assincrono irá retornar
           o valores de QtdNotasProcessadas, ValorTotalServicos e ValorTotalDeducoes com zero. E deverá ser executado a função ConsultarLote 
           para obter o resultado do processamento do lote. */
        [DllImport("lotenfse.dll")]
        private static extern int Enviar(IntPtr DocAssinatura,
                              ref StringBuilder Assincrono,
                              ref StringBuilder Sucesso,
                                        ref int NumeroLote,
                                        ref int QtdNotasProcessadas,
                                     ref double ValorTotalServicos,
                                     ref double ValorTotalDeducoes,
                                        ref int Erros,
                                        ref int Alertas);

        [DllImport("lotenfse.dll")]
        private static extern int TesteEnviar(IntPtr DocAssinatura,
                              ref StringBuilder Assincrono,
                              ref StringBuilder Sucesso,
                                        ref int NumeroLote,
                                        ref int QtdNotasProcessadas,
                                     ref double ValorTotalServicos,
                                     ref double ValorTotalDeducoes,
                                        ref int Erros,
                                        ref int Alertas);
        /*
           Obs.: Na função Enviar o parâmetro DocAssinatura, irá indicar se a DLL deverá assinar ou não o XML a ser enviado ao WebService.
           Caso o valor do DocAssinatura for 'S' a DLL irá realizar a assinatura digital com o certificado a ser selecionado numa caixa de diálogo que irá
           aparecer no momento da chamada da função. Para o servidor de homologação não é necessário assinar o lote, porém no serviço de produção é
           obrigatório.      Antes de utilizar a assinatura digital é necessário verificar se o procedimento indicado no arquivo Leia-me.txt foi realizado.
        */


        /*
           Se após executar a função Enviar o serviço for sincrono  e a quantidade de notas retornadas no parâmetro QtdNotasProcessadas da função Enviar
        for maior que zero, então pode fazer um loop bucando os dados de cada nota através da função abaixo. */
        [DllImport("lotenfse.dll")]
        private static extern int ObterNotaRetorno(int RetornoItem,
                                     ref StringBuilder InscricaoPrestador,
                                               ref int NumeroNFe,
                                     ref StringBuilder CodigoVerificacao,
                                     ref StringBuilder RazaoSocialPrestador,
                                     ref StringBuilder SerieRPS,
                                               ref int NumeroRPS,
                                     ref StringBuilder DataEmissaoRPS);
        [DllImport("lotenfse.dll")]
        private static extern StringBuilder ObterXmlEnvio(IntPtr pDocAssinatura, IntPtr pMetodo, IntPtr pVersaoComponente);

        /////////////////////FUNÇÕES UTILIZADAS PARA REALIZAR A CONSULTA DE LOTE, E BUSCAR O RESULTADO DE SEU PROCESSAMENTO ///////////////////////////
        /*
           A função abaixo é utilizada para buscar as informações do lote,
           Após o envio do lote na função Enviar pega-se o número do lote gerado.
           Pode-se então consultar os dados do processamento do lote pela função ConsultarLote, caso o lote ainda não estiver processado
           o parâmetro Sucesso retorna falso e a função ConsultarLote irá retornar um alerta,
           caso o lote tenha sido processado irá retornar a quantidade de notas processadas, erros e alertas ocorridos  */
        [DllImport("lotenfse.dll")]
        private static extern int ConsultarLote(int CodCidade,
                                             IntPtr CPFCNPJRemetente,
                                                int NumeroLote,
                                  ref StringBuilder Sucesso,
                                  ref StringBuilder DataEnvioLote,
                                            ref int QtdNotasProcessadas,
                                  ref StringBuilder TempoProcessamento,
                                         ref double ValorTotalServicos,
                                         ref double ValotTotalDeducoes,
                                            ref int Alertas,
                                            ref int Erros);


        /* Função para buscar as Notas do Lote, apos executar a função ConsultarLote  pode-se obter os dados das notas com a função abaixo.
          Por exemplo se o ConsultarLote retornou 10 notas no parâmetro QtdNotasProcessadas, deve-se realizar um loop do item 0 ao 9
          executando a função abaixo para pegar os dados da nota.
          Se ocorreram erros no processamento do lote, o lote será recusado, o parâmetro do QtdNotasProcessadas irá retornar zero,
          e o parâmetro Erros da função ConsultarLote irá retornar a quantidade de erros ocorridos.
          Por exemplo se o ConsultarLote retorno no parâmetro Erros, 10 erros ocorridos. Deve-se fazer um loop de 0 a 9
          chamando a função ObterErroLote, passando como parâmetro o ErroItem, para pegar os dados do erro ocorrido. */
        [DllImport("lotenfse.dll")]
        private static extern int ObterNotaDoConsultarLote(int NrItem,
                                             ref StringBuilder InscricaoPrestador,
                                                       ref int NumeroNFe,
                                             ref StringBuilder CodigoVerificacao,
                                             ref StringBuilder SerieRPS,
                                                       ref int NumeroRPS,
                                             ref StringBuilder DataEmissaoRPS,
                                             ref StringBuilder RazaoSocialPrestador,
                                             ref StringBuilder TipoRecolhimento,
                                                    ref double ValorDeduzir,
                                                    ref double ValorTotal,
                                                    ref double Aliquota);




        /////////////////////////////////////FUNÇÕES UTILIZADAS PARA RECUPERAÇÃO DE NOTAS CONVERTIDAS /////////////////////////////////////

        //Função para consultar notas geradas em determinado periodo.
        //Função para consultar as notas convertidas em determinado periodo. Cada requizição de consulta de notas retorna no máximo 100 notas,
        //com isso caso o periodo informado tenha mais de 100 notas é necessario fazer mais de uma requizição, para esse caso existe o campo NotaInicial.
        //Neste campo pode ser informado a partir de qual numero de nota deseja-se obter o retorno. Por exemplo se você deseja consultar o periodo de 01/05/2010 ate 20/05/2010 , você faz a primeira chamada
        //da função ConsultarNotas passando o periodo e no campo NotaInicial passe o valor zero. Ou seja será retornado todas as notas do periodo até o limite de 100 notas, onde o numero da nota for maior ou igual a zero, em seguida você chama a função
        //ObterNotaDoConsultarNotas para obter as informações das 100 notas retornadas. Em seguida para obter as próximas 100 notas você deve chamar novamente a função ConsultaNotasConvertidas informando o mesmo periodo e no NotaInicial você informa o numero da última nota retornada mais um.
        //E assim repetidamente até que o parâmetro QtdNotas retorne zero indicando que não existe nenhuma nota a mais no periodo.
        [DllImport("lotenfse.dll")]
        private static extern int ConsultarNotasConvertidas(IntPtr pDocAssinatura,
                                                               int CodCidade,
                                                            IntPtr CPFCNPJRemetente,
                                                            IntPtr InscricaoMunicipalPrestador,
                                                            IntPtr DataInicio,
                                                            IntPtr DataTermino,
                                                               int NotaInicial,
                                                           ref int QtdNotas, ref int Erros);


        /*
           A função  ConsultarNotas irá retornar o parâmetro QtdNotas, que é a quantidade de notas obtidas no período.
           Por exemplo, caso o parâmetro tenha retornado 10 notas, deve-se fazer um loop de 0 a 9 fazendo chamada a função  NotaConsultarNotas abaixo,
           passando como parâmetro a posição no PosNotaConsulta, e a função irá retornar os dados de cada nota que foi gravada na memória na função ConsultarNotas.
           */
        [DllImport("lotenfse.dll")]
        private static extern int ObterNotaDoConsultarNotasV1(int PosNotaConsulta, //Posição na lista de nota obtidas com a função ConsultarNotas. Se retornou 10 notas, setar na posição 0 a 9
                                                       ref int NumeroNota,
                                             ref StringBuilder DataProcessamento,
                                                       ref int NumeroLote,
                                             ref StringBuilder CodigoVerificacao,
                                             ref StringBuilder Assinatura,
                                             ref StringBuilder InscricaoMunicipalPrestador,
                                             ref StringBuilder RazaoSocialPrestador,
                                             ref StringBuilder TipoRPS,
                                             ref StringBuilder SerieRPS,
                                                       ref int NumeroRPS,
                                             ref StringBuilder DataEmissaoRPS,
                                             ref StringBuilder SituacaoRPS,
                                             ref StringBuilder SerieRPSSubstituido,
                                                       ref int NumeroRPSSubstituido,
                                                       ref int NumeroNFSeSubstituida,
                                             ref StringBuilder DataEmissaoNFSeSubstituida,
                                             ref StringBuilder SeriePrestacao,
                                             ref StringBuilder nscricaoMunicipalTomador,
                                             ref StringBuilder CPFCNPJTomador,
                                             ref StringBuilder RazaoSocialTomador,
                                             ref StringBuilder DocTomadorEstrangeiro,
                                             ref StringBuilder TipoLogradouroTomador,
                                             ref StringBuilder LogradouroTomador,
                                             ref StringBuilder NumeroEnderecoTomador,
                                             ref StringBuilder ComplementoEnderecoTomador,
                                             ref StringBuilder TipoBairroTomador,
                                             ref StringBuilder BairroTomador,
                                             ref StringBuilder CidadeTomador,
                                             ref StringBuilder CidadeTomadorDescricao,
                                             ref StringBuilder CEPTomador,
                                             ref StringBuilder EmailTomador,
                                             ref StringBuilder CodigoAtividade,
                                                    ref double AliquotaAtividade,
                                             ref StringBuilder TipoRecolhimento,
                                                       ref int MunicipioPrestacao,
                                             ref StringBuilder MunicipioPrestacaoDescricao,
                                             ref StringBuilder Operacao,
                                             ref StringBuilder Tributacao,
                                                    ref double ValorPIS,
                                                    ref double ValorCOFINS,
                                                    ref double ValorINSS,
                                                    ref double ValorIR,
                                                    ref double ValorCSLL,
                                                    ref double AliquotaPIS,
                                                    ref double AliquotaCOFINS,
                                                    ref double AliquotaINSS,
                                                    ref double AliquotaIR,
                                                    ref double AliquotaCSLL,
                                             ref StringBuilder DescricaoRPS,
                                             ref StringBuilder DDDPrestador,
                                             ref StringBuilder TelefonePrestador,
                                             ref StringBuilder DDDTomador,
                                             ref StringBuilder TelefoneTomador,
                                             ref StringBuilder MotCancelamento,
                                             ref StringBuilder CpfCnpjIntermediario,
                                                       ref int Deducoes,
                                                       ref int Itens);


        /*
          Caso nos dados de retorno da função ObterNotaDoConsultarNotas declarada acima o parâmetro deduções vier diferente de zero,
          deverá ser executada a função abaixo para pegar cada item de dedução da nota.
          Por exemplo se o parâmetro Deducoes da função ObterNotaDoConsultarNotas retornar valor 5,
          deve-se fazer um loop de 0 a 4 executando chamada a função abaixo, passando como parâmetro o PosNotaConsulta passado na função ObterNotaDoConsultarNotas,
          e o PosDeducaoNotaConsulta, que é o item de 0 a 4 . */
        [DllImport("lotenfse.dll")]
        private static extern int ObterDecucaoNota(int PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                                   int PosDeducaoNotaConsulta,
                                     ref StringBuilder DeducaoPor,
                                     ref StringBuilder TipoDeducao,
                                     ref StringBuilder CPFCNPJReferencia,
                                               ref int NumeroNFReferencia,
                                            ref double ValorTotalReferencia,
                                            ref double PercentualDeduzir,
                                            ref double ValorDeduzir);

        /*
           Caso nos dados de retorno da funçao ObterNotaDoConsultarNotas declarada mais acima, o parâmetro itens irá retornar o número de itens de serviço da nota,
           Deverá então ser executada a função abaixo para buscar cada item de serviço.
           Por exemplo se o parâmetro Itens da função ObterNotaDoConsultarNotas retornar valor 5 a nota possui cinco itens de serviço, e deve-se executar um loop
           da posição 0 a 4 pegando cada item usando a função abaixo.
           */
        [DllImport("lotenfse.dll")]
        private static extern int ObterItemServicoNota(int PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                                       int PosItemNotaConsulta,
                                         ref StringBuilder DiscriminacaoServico,
                                                ref double Quantidade,
                                                ref double ValorUnitario,
                                                ref double ValorTotal,
                                         ref StringBuilder Tributavel);
        // Função utilizada para obter os Erros retornados pela função ConsultarNotasConvertdias
        [DllImport("lotenfse.dll")]
        private static extern int ObterErroConsultarNota(int RetornoItem,
                                                     ref int pCodigo,
                                           ref StringBuilder pDescricao);


        ///////////////////// AS FUNÇÕES ABAIXO SÃO EXECUTADAS PARA PEGAR OS ERROS E ALERTAS DE RETORNO DO LOTE ///////////
        ///  AS FUNÇÕES SÃO NECESSARIAS PARA PEGAR OS DADOS DO ERRO OU ALERTA NAS FUNÇÕES Enviar e ConsultarLote

        /*
           Caso tenha algum Erro de retorno no envio do lote ou na consulta de lote, a função abaixo  pega os dados do erro.
           Por exemplo se a função ConsultarLote retornou no parâmetro Erros o valor 5. Deve-se fazer um loop de 0 a 4 passando a posição do ErroItem de erro
           fazendo chamada  a função abaixo */
        [DllImport("lotenfse.dll")]
        private static extern int ObterErroLote(int ErroItem,
                                            ref int Codigo,
                                  ref StringBuilder Descricao,
                                  ref StringBuilder InscricaoPrestador,
                                  ref StringBuilder SerieRPS,
                                            ref int NumeroRPS,
                                  ref StringBuilder DataEmissaoRPS,
                                  ref StringBuilder RazaoSocialPrestador);


        //Caso tenha algum Alerta de retorno no envio da declaração ou na consulta de lote, a funçao abaixo  pega os dados do alerta.
        /* Por exemplo se a função ConsultarLote retornou no parâmetro Alertas o valor 5. Deve-se fazer um loop de 0 a 4 passando a posição do ErroItem de erro
           fazendo chamada  a função abaixo */
        [DllImport("lotenfse.dll")]
        private static extern int ObterAlertaLote(int ErroItem,
                                              ref int Codigo,
                                    ref StringBuilder Descricao,
                                    ref StringBuilder InscricaoPrestador,
                                    ref StringBuilder SerieRPS,
                                              ref int NumeroRPS,
                                    ref StringBuilder DataEmissaoRPS,
                                    ref StringBuilder RazaoSocialPrestador);

        /////////// A FUNÇÃO ABAIXO É UTILIZADA PARA PEGAR O NÚMERO DO ÚLTIMO RPS CONVERTIDO EM NOTA. /////////////////////
        /* A númeração dos RPS devem ser sequênciais, por exemplo se o número do último RPS convertido em nota for o 11, o próximo a ser enviado
        no próximo lote deve ser obrigatóriamente o 12, sendo que a númeração dos RPS no lote também devem ser sequênciais. */


        //Consulta sequêncial do RPS, pega o número do último RPS convertido pelo contribuinte
        [DllImport("lotenfse.dll")]
        private static extern int ConsultarSequencial(int CodCidade,
                                               IntPtr CPFCNPJRemetente,
                                               IntPtr InscricaoMunicipalPrestador,
                                               IntPtr SeriePrestacao,
                                              ref int NroUltimoRps);

        ///////////////////////////////FUNÇÃO UTILIZADA PARA PEGAR ALGUM ERRO INTERNO DA DLL, RETORNADO NA CHAMADA DE ALGUMA FUNÇÃO ////
        //Caso tenha retornado um erro em alguma das funções pode se consultar a descrição do erro ocorrido nesta função.
        [DllImport("lotenfse.dll")]
        private static extern StringBuilder ObterErroInterno(int CodErro);

        ///////////////////////////////FUNÇÃO UTILIZADA PARA SETAR PARAMETROS DE PROXY E CADEIA DE CERTIFICAÇÃO UTILIZADO NO CERTIFICADO DIGITAL ////
        [DllImport("lotenfse.dll")]
        private static extern void Configurar(int Proxy,
                                             IntPtr pEndereco,
                                             IntPtr pPorta,
                                             IntPtr pUser,
                                             IntPtr pSenha,
                                             IntPtr pCadeiaCert,
                                             IntPtr pCacheLCR);



        ///////////////////////////////FUNÇÕES UTILIZADAS NO CANCELAMENTO DE NOTA FISCAL /////////////////////////////////////////////


        /// CRIAR LOTE DE SOLICITAÇÃO DE CANCELAMENTO DE NOTA FISCAL
        [DllImport("lotenfse.dll")]
        private static extern int CriarLoteCancelamento(int CodCidade,
                                                     IntPtr CPFCNPJRemetente,
                                                     IntPtr RazaoSocialRemetente);

        //ADICIONA NOTA AO LOTE DE CANCELAMENTO DE NOTA FISCAL CRIADO NA FUNÇÃO ANTERIOR
        [DllImport("lotenfse.dll")]
        private static extern int AdicionarNotaCancelamento(IntPtr InscricaoMunicipalPrestador,
                                                                int NumeroNota,
                                                             IntPtr CodigoVerificacao,
                                                             IntPtr MotivoCancelamento);

        //ENVIA LOTE COM AS NOTAS FISCAIS A SEREM CANCELADAS
        [DllImport("lotenfse.dll")]
        private static extern int EnviarCancelamento(IntPtr pDocAssinatura,
                                          ref StringBuilder pSucesso,
                                                    ref int pQtdNotasCanceladas,
                                                    ref int pErros,
                                                    ref int pAlertas);
        //FUNÇÃO PARA OBTER AS NOTAS CANCELADAS, OBTÉM O RETORNO DO ENVIARCANCELAMENTO
        //Por exemplo se no parâmetro de retorno pQtdNotasCanceladas do EnviarCancelamento retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função ObterNotaRetornoCancelamento passando no parametro RetornoItem a pósição .
        [DllImport("lotenfse.dll")]
        private static extern int ObterNotaRetornoCancelamento(int RetornoItem, //Posição da lista de notas canceladas retornadas
                                                 ref StringBuilder pInscricaoPrestador,
                                                           ref int pNumeroNota,
                                                 ref StringBuilder pCodigoVerificacao);

        //FUNÇÃO PARA OBTER OS ERROS NO CANCELAMENTO, OBTÉM O RETORNO DO ENVIARCANCELAMENTO
        //Por exemplo se no parâmetro de retorno pErros do EnviarCancelamento retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro ErroItem a pósição .
        [DllImport("lotenfse.dll")]
        private static extern int ObterErroLoteCancelamento(int ErroItem,
                                                        ref int pCodigo,
                                              ref StringBuilder pDescricao,
                                              ref StringBuilder pInscricaoPrestador,
                                                        ref int pNumeroNFe,
                                              ref StringBuilder pCodigoVerificacao);
        //FUNÇÃO PARA OBTER OS ALERTAS NO CANCELAMENTO, OBTÉM O RETORNO DO ENVIARCANCELAMENTO
        //Por exemplo se no parâmetro de retorno pAlertas do EnviarCancelamento retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro AlertaItem a pósição .


        [DllImport("lotenfse.dll")]
        private static extern int ObterAlertaLoteCancelamento(int AlertaItem,
                                                          ref int pCodigo,
                                                ref StringBuilder pDescricao,
                                                ref StringBuilder pInscricaoPrestador,
                                                          ref int pNumeroNFe,
                                                ref StringBuilder pCodigoVerificacao);







        // CRIAR LOTE DE SOLICITAÇÃO DE CONSULTA NFSe
        [DllImport("lotenfse.dll")]
        private static extern int CriarLoteConsultaNFSeRPS(int CodCidade,
                                                        IntPtr CPFCNPJRemetente,
                                                        IntPtr RazaoSocialRemetente);


        //Adicionar NFSe a ser consultada ao lote de consulta criado na função anterior
        [DllImport("lotenfse.dll")]
        private static extern int AdicionarNFSeConsultaNFSeRPS(IntPtr InscricaoMunicipalPrestador,
                                                               int NumeroNota,
                                                            IntPtr CodigoVerificacao);

        //Adicionar RPS a ser consultado ao lote de Consulta criado na função CriarLoteConsultaNFSeRPS
        [DllImport("lotenfse.dll")]
        private static extern int AdicionarRPSConsultaNFSeRPS(IntPtr InscricaoMunicipalPrestador,
                                                             int NumeroRPS,
                                                          IntPtr SeriePrestacao);


        //Enviar lote de consulta de NFSe ou RPS
        [DllImport("lotenfse.dll")]
        private static extern int EnviarConsultaNFSeRPS(IntPtr pDocAssinatura,
                                             ref StringBuilder pSucesso,
                                                       ref int pQtdNotasConsultaNFSe,
                                                       ref int pErros,
                                                       ref int pAlertasr);

        //FUNÇÃO PARA OBTER AS NOTAS CONSULTADAS, OBTÉM O RETORNO DO EnviarConsultaNFSe
        //Por exemplo se no parâmetro de retorno pQtdNotasConsultaNFSe do EnviarConsultaNFSeRPS retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função ObterNotaRetornoConsultaNFSeRPS passando no parametro RetornoItem a posição .
        [DllImport("lotenfse.dll")]
        private static extern int ObterNotaRetornoNFSeRPSV1(int RetornoItem,
                                                       ref int pNumeroNota,
                                            ref StringBuilder pDataProcessamento,
                                                       ref int pNumeroLote,
                                            ref StringBuilder pCodigoVerificacao,
                                            ref StringBuilder pAssinatura,
                                            ref StringBuilder pInscricaoMunicipalPrestador,
                                            ref StringBuilder pRazaoSocialPrestador,
                                            ref StringBuilder pTipoRPS,
                                            ref StringBuilder pSerieRPS,
                                                      ref int pNumeroRPS,
                                            ref StringBuilder pDataEmissaoRPS,
                                            ref StringBuilder pSituacaoRPS,
                                            ref StringBuilder pSerieRPSSubstituido,
                                                      ref int pNumeroRPSSubstituido,
                                                       ref int pNumeroNFSeSubstituida,
                                            ref StringBuilder pDataEmissaoNFSeSubstituida,
                                            ref StringBuilder pSeriePrestacao,
                                            ref StringBuilder pInscricaoMunicipalTomador,
                                            ref StringBuilder pCPFCNPJTomador,
                                            ref StringBuilder pRazaoSocialTomador,
                                            ref StringBuilder pDocTomadorEstrangeiro,
                                            ref StringBuilder pTipoLogradouroTomador,
                                            ref StringBuilder pLogradouroTomador,
                                            ref StringBuilder pNumeroEnderecoTomador,
                                            ref StringBuilder pComplementoEnderecoTomador,
                                            ref StringBuilder pTipoBairroTomador,
                                            ref StringBuilder pBairroTomador,
                                            ref StringBuilder pCidadeTomador,
                                            ref StringBuilder pCidadeTomadorDescricao,
                                            ref StringBuilder pCEPTomador,
                                            ref StringBuilder pEmailTomador,
                                            ref StringBuilder pCodigoAtividade,
                                                   ref double pAliquotaAtividade,
                                            ref StringBuilder pTipoRecolhimento,
                                                      ref int pMunicipioPrestacao,
                                            ref StringBuilder pMunicipioPrestacaoDescricao,
                                            ref StringBuilder pOperacao,
                                            ref StringBuilder pTributacao,
                                                    ref double pValorPIS,
                                                    ref double pValorCOFINS,
                                                    ref double pValorINSS,
                                                    ref double pValorIR,
                                                    ref double pValorCSLL,
                                                    ref double pAliquotaPIS,
                                                    ref double pAliquotaCOFINS,
                                                    ref double pAliquotaINSS,
                                                    ref double pAliquotaIR,
                                                    ref double pAliquotaCSLL,
                                             ref StringBuilder pDescricaoRPS,
                                             ref StringBuilder pDDDPrestador,
                                             ref StringBuilder pTelefonePrestador,
                                             ref StringBuilder pDDDTomador,
                                             ref StringBuilder pTelefoneTomador,
                                             ref StringBuilder pMotCancelamento,
                                             ref StringBuilder pCpfCnpjIntermediario,
                                                       ref int pDeducoes,
                                                       ref int pItens);

        //Função para obter os itens de dedução da ConsultaNFSeRPS
        [DllImport("lotenfse.dll")]
        private static extern int ObterDecucaoNFSeRPS(int PosNotaConsulta,
                                                      int PosDeducaoNotaConsulta,
                                        ref StringBuilder pDeducaoPor,
                                        ref StringBuilder pTipoDeducao,
                                        ref StringBuilder pCPFCNPJReferencia,
                                                  ref int pNumeroNFReferencia,
                                               ref double pValorTotalReferencia,
                                               ref double pPercentualDeduzir,
                                               ref double pValorDeduzir);

        //Função para obter os itens de serviços da ConsultaNFSeRPS
        [DllImport("lotenfse.dll")]
        private static extern int ObterItemServicoNFSeRPS(int PosNotaConsulta,
                                                          int PosItemNotaConsulta,
                                            ref StringBuilder pDiscriminacaoServico,
                                                   ref double pQuantidade,
                                                   ref double pValorUnitario,
                                                   ref double pValorTotal,
                                            ref StringBuilder pTributavel);

        //FUNÇÃO PARA OBTER OS ERROS NA CONSULTANFSERPS, OBTÉM OS ERROS DE RETORNO DO ENVIARCONSULTANFSERPS
        //Por exemplo se no parâmetro de retorno pErros do EnviarConsultaNFSeRPS retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro ErroItem a posição .
        [DllImport("lotenfse.dll")]
        private static extern int ObterErroConsultaNFSeRPS(int ErroItem,
                                                       ref int pCodigo,
                                             ref StringBuilder pDescricao);
        //FUNÇÃO PARA OBTER OS ALERTAS NO CONSULTANFSeRPS, OBTÉM OS ALERTAS DE RETORNO DO ENVIARCONSULTANFSeRPS
        //Por exemplo se no parâmetro de retorno pAlertas do EnviarConsultaNFSeRPS retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro AlertaItem a posição .
        [DllImport("lotenfse.dll")]
        private static extern int ObterAlertaConsultaNFSeRPS(int AlertaItem,
                                                         ref int pCodigo,
                                               ref StringBuilder pDescricao);




        /* FUNÇÃO USADA PARA APONTAR O WEB SERVICE
         */
        private void dllSetURL(string varsRPS_HTTPSURL, string varsRPS_HTTPSWSDL)
        {
            //Aloca mémoria das variaveis por valor
            IntPtr ptrUrl1 = Marshal.StringToHGlobalAnsi(varsRPS_HTTPSURL);
            IntPtr ptrUrl2 = Marshal.StringToHGlobalAnsi(varsRPS_HTTPSWSDL);
            setURL(ptrUrl1, ptrUrl2);

            //Libera memoria
            Marshal.FreeHGlobal(ptrUrl1);
            Marshal.FreeHGlobal(ptrUrl2);
        }
        /* Funcao para obter erro interno retornado pela DLL */

        public string dllObterErroInterno(int CodErro)
        {
            StringBuilder retorno = new StringBuilder(2000);
            retorno = ObterErroInterno(CodErro);
            return retorno.ToString();
        }
        public int dllSetGravaArquivoXML(string Caminho)
        {
            IntPtr ptrCaminho = Marshal.StringToHGlobalAnsi(Caminho);
            int retorno = setGravaArquivoXML(ptrCaminho);
            Marshal.FreeHGlobal(ptrCaminho);
            return retorno;

        }

        public int dllConsultarSequencial(int CodCidade,
                                   string CPFCNPJRemetente,
                                   string InscricaoMunicipalPrestador,
                                   string SeriePrestacao,
                                  ref int NroUltimoRps)
        {




            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);
            //Aloca memória das variaveis por valor
            IntPtr ptrCPFCNPJRemetente = Marshal.StringToHGlobalAnsi(CPFCNPJRemetente);
            IntPtr ptrInscricaoMunicipalPrestador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalPrestador);
            IntPtr pSeriePretacao = Marshal.StringToHGlobalAnsi(SeriePrestacao);
            int erroRetorno = ConsultarSequencial(CodCidade,
                                  ptrCPFCNPJRemetente,
                                  ptrInscricaoMunicipalPrestador,
                                  pSeriePretacao,
                              ref NroUltimoRps);
            //Libera memoria
            Marshal.FreeHGlobal(ptrCPFCNPJRemetente);
            Marshal.FreeHGlobal(ptrInscricaoMunicipalPrestador);
            Marshal.FreeHGlobal(pSeriePretacao);

            return erroRetorno;
        }


        public int dllCriarLote(int CodCidade,
                             string CPFCNPJRemetente,
                             string RazaoSocialRemetente)
        {
            IntPtr ptrCPFCNPJRemetente = Marshal.StringToHGlobalAnsi(CPFCNPJRemetente);
            IntPtr ptrRazaoSocialRemetente = Marshal.StringToHGlobalAnsi(RazaoSocialRemetente);
            int retorno = CriarLote(CodCidade,
                           ptrCPFCNPJRemetente,
                           ptrRazaoSocialRemetente);
            //Libera memoria
            Marshal.FreeHGlobal(ptrCPFCNPJRemetente);
            Marshal.FreeHGlobal(ptrRazaoSocialRemetente);
            return retorno;
        }


        public int dllAdicionarRPSV1(string InscricaoMunicipalPrestador,
                                    string RazaoSocialPrestador,
                                    string TipoRPS,
                                    string SerieRPS,
                                       int NumeroRPS,
                                    string DataEmissaoRPS,
                                    string SituacaoRPS,
                                    string SerieRPSSubstituido,
                                       int NumeroRPSSubstituido,
                                       int NumeroNFSeSubstituida,
                                    string DataEmissaoNFSeSubstituida,
                                    string SeriePrestacao,
                                    string InscricaoMunicipalTomador,
                                    string CPFCNPJTomador,
                                    string RazaoSocialTomador,
                                    string DocTomadorEstrangeiro,
                                    string TipoLogradouroTomador,
                                    string LogradouroTomador,
                                    string NumeroEnderecoTomador,
                                    string ComplementoTomador,
                                    string TipoBairroTomador,
                                    string BairroTomador,
                                       int CidadeTomador,
                                    string CidadeTomadorDescricao,
                                    string CEPTomador,
                                    string EmailTomador,
                                    string CodigoAtividade,
                                    double AliquotaAtividade,
                                    string TipoRecolhimento,
                                       int MunicipioPrestacao,
                                    string MunicipioPrestacaoDescricao,
                                    string Operacao,
                                    string Tributacao,
                                    double ValorPIS,
                                    double ValorCOFINS,
                                    double ValorINSS,
                                    double ValorIR,
                                    double ValorCSLL,
                                    double AliquotaPIS,
                                    double AliquotaCOFINS,
                                    double AliquotaINSS,
                                    double AliquotaIR,
                                    double AliquotaCSLL,
                                    string DescricaoRPS,
                                    string DDDPrestador,
                                    string TelefonePrestador,
                                    string DDDTomador,
                                    string TelefoneTomador,
                                    string MotCancelamento,
                                    string CpfCnpjIntermediario)
        {

            IntPtr PtrInscricaoMunicipalPrestador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalPrestador);
            IntPtr PtrRazaoSocialPrestador = Marshal.StringToHGlobalAnsi(RazaoSocialPrestador);
            IntPtr PtrTipoRPS = Marshal.StringToHGlobalAnsi(TipoRPS);
            IntPtr PtrSerieRPS = Marshal.StringToHGlobalAnsi(SerieRPS);
            IntPtr PtrDataEmissaoRPS = Marshal.StringToHGlobalAnsi(DataEmissaoRPS);
            IntPtr PtrSituacaoRPS = Marshal.StringToHGlobalAnsi(SituacaoRPS);
            IntPtr PtrSerieRPSSubstituido = Marshal.StringToHGlobalAnsi(SerieRPSSubstituido);
            IntPtr PtrDataEmissaoNFSeSubstituida = Marshal.StringToHGlobalAnsi(DataEmissaoNFSeSubstituida);
            IntPtr PtrSeriePrestacao = Marshal.StringToHGlobalAnsi(SeriePrestacao);
            IntPtr PtrInscricaoMunicipalTomador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalTomador);
            IntPtr PtrCPFCNPJTomador = Marshal.StringToHGlobalAnsi(CPFCNPJTomador);
            IntPtr PtrRazaoSocialTomador = Marshal.StringToHGlobalAnsi(RazaoSocialTomador);
            IntPtr PtrDocTomadorEstrangeiro = Marshal.StringToHGlobalAnsi(DocTomadorEstrangeiro);
            IntPtr PtrTipoLogradouroTomador = Marshal.StringToHGlobalAnsi(TipoLogradouroTomador);
            IntPtr PtrLogradouroTomador = Marshal.StringToHGlobalAnsi(LogradouroTomador);
            IntPtr PtrNumeroEnderecoTomador = Marshal.StringToHGlobalAnsi(NumeroEnderecoTomador);
            IntPtr PtrComplementoTomador = Marshal.StringToHGlobalAnsi(ComplementoTomador);
            IntPtr PtrTipoBairroTomador = Marshal.StringToHGlobalAnsi(TipoBairroTomador);
            IntPtr PtrBairroTomador = Marshal.StringToHGlobalAnsi(BairroTomador);
            IntPtr PtrCidadeTomadorDescricao = Marshal.StringToHGlobalAnsi(CidadeTomadorDescricao);
            IntPtr PtrCEPTomador = Marshal.StringToHGlobalAnsi(CEPTomador);
            IntPtr PtrEmailTomador = Marshal.StringToHGlobalAnsi(EmailTomador);
            IntPtr PtrCodigoAtividade = Marshal.StringToHGlobalAnsi(CodigoAtividade);
            IntPtr PtrTipoRecolhimento = Marshal.StringToHGlobalAnsi(TipoRecolhimento);
            IntPtr PtrMunicipioPrestacaoDescricao = Marshal.StringToHGlobalAnsi(MunicipioPrestacaoDescricao);
            IntPtr PtrOperacao = Marshal.StringToHGlobalAnsi(Operacao);
            IntPtr PtrTributacao = Marshal.StringToHGlobalAnsi(Tributacao);
            IntPtr PtrDescricaoRPS = Marshal.StringToHGlobalAnsi(DescricaoRPS);
            IntPtr PtrDDDPrestador = Marshal.StringToHGlobalAnsi(DDDPrestador);
            IntPtr PtrTelefonePrestador = Marshal.StringToHGlobalAnsi(TelefonePrestador);
            IntPtr PtrDDDTomador = Marshal.StringToHGlobalAnsi(DDDTomador);
            IntPtr PtrTelefoneTomador = Marshal.StringToHGlobalAnsi(TelefoneTomador);
            IntPtr PtrMotCancelamento = Marshal.StringToHGlobalAnsi(MotCancelamento);
            IntPtr PtrCpfCnpjIntermediario = Marshal.StringToHGlobalAnsi(CpfCnpjIntermediario);

            //Faz chamada ao método da DLL
            int erroRetorno = AdicionarRPSV1(PtrInscricaoMunicipalPrestador,
                                               PtrRazaoSocialPrestador,
                                               PtrTipoRPS,
                                               PtrSerieRPS,
                                               NumeroRPS,
                                               PtrDataEmissaoRPS,
                                               PtrSituacaoRPS,
                                               PtrSerieRPSSubstituido,
                                               NumeroRPSSubstituido,
                                               NumeroNFSeSubstituida,
                                               PtrDataEmissaoNFSeSubstituida,
                                               PtrSeriePrestacao,
                                               PtrInscricaoMunicipalTomador,
                                               PtrCPFCNPJTomador,
                                               PtrRazaoSocialTomador,
                                               PtrDocTomadorEstrangeiro,
                                               PtrTipoLogradouroTomador,
                                               PtrLogradouroTomador,
                                               PtrNumeroEnderecoTomador,
                                               PtrComplementoTomador,
                                               PtrTipoBairroTomador,
                                               PtrBairroTomador,
                                               CidadeTomador,
                                               PtrCidadeTomadorDescricao,
                                               PtrCEPTomador,
                                               PtrEmailTomador,
                                               PtrCodigoAtividade,
                                               AliquotaAtividade,
                                               PtrTipoRecolhimento,
                                               MunicipioPrestacao,
                                               PtrMunicipioPrestacaoDescricao,
                                               PtrOperacao,
                                               PtrTributacao,
                                               ValorPIS,
                                               ValorCOFINS,
                                               ValorINSS,
                                               ValorIR,
                                               ValorCSLL,
                                               AliquotaPIS,
                                               AliquotaCOFINS,
                                               AliquotaINSS,
                                               AliquotaIR,
                                               AliquotaCSLL,
                                               PtrDescricaoRPS,
                                               PtrDDDPrestador,
                                               PtrTelefonePrestador,
                                               PtrDDDTomador,
                                               PtrTelefoneTomador,
                                               PtrMotCancelamento,
                                               PtrCpfCnpjIntermediario);
            //Libera memória alocada pelos ponteiros
            Marshal.FreeHGlobal(PtrInscricaoMunicipalPrestador);
            Marshal.FreeHGlobal(PtrRazaoSocialPrestador);
            Marshal.FreeHGlobal(PtrTipoRPS);
            Marshal.FreeHGlobal(PtrSerieRPS);
            Marshal.FreeHGlobal(PtrDataEmissaoRPS);
            Marshal.FreeHGlobal(PtrSituacaoRPS);
            Marshal.FreeHGlobal(PtrSerieRPSSubstituido);
            Marshal.FreeHGlobal(PtrDataEmissaoNFSeSubstituida);
            Marshal.FreeHGlobal(PtrSeriePrestacao);
            Marshal.FreeHGlobal(PtrInscricaoMunicipalTomador);
            Marshal.FreeHGlobal(PtrCPFCNPJTomador);
            Marshal.FreeHGlobal(PtrRazaoSocialTomador);
            Marshal.FreeHGlobal(PtrDocTomadorEstrangeiro);
            Marshal.FreeHGlobal(PtrTipoLogradouroTomador);
            Marshal.FreeHGlobal(PtrLogradouroTomador);
            Marshal.FreeHGlobal(PtrNumeroEnderecoTomador);
            Marshal.FreeHGlobal(PtrComplementoTomador);
            Marshal.FreeHGlobal(PtrTipoBairroTomador);
            Marshal.FreeHGlobal(PtrBairroTomador);
            Marshal.FreeHGlobal(PtrCidadeTomadorDescricao);
            Marshal.FreeHGlobal(PtrCEPTomador);
            Marshal.FreeHGlobal(PtrEmailTomador);
            Marshal.FreeHGlobal(PtrCodigoAtividade);
            Marshal.FreeHGlobal(PtrTipoRecolhimento);
            Marshal.FreeHGlobal(PtrMunicipioPrestacaoDescricao);
            Marshal.FreeHGlobal(PtrOperacao);
            Marshal.FreeHGlobal(PtrTributacao);
            Marshal.FreeHGlobal(PtrDescricaoRPS);
            Marshal.FreeHGlobal(PtrDDDPrestador);
            Marshal.FreeHGlobal(PtrTelefonePrestador);
            Marshal.FreeHGlobal(PtrDDDTomador);
            Marshal.FreeHGlobal(PtrTelefoneTomador);
            Marshal.FreeHGlobal(PtrMotCancelamento);
            Marshal.FreeHGlobal(PtrCpfCnpjIntermediario);
            return erroRetorno;


        }


        public int dllAdicionarItemServicoRPS(string DiscriminacaoServico,
                                              double Quantidade,
                                              double ValorUnitario,
                                              string Tributavel)
        {
            IntPtr ptrDiscriminacaoServico = Marshal.StringToHGlobalAnsi(DiscriminacaoServico);
            IntPtr ptrTributavel = Marshal.StringToHGlobalAnsi(Tributavel);

            int erroRetorno = AdicionarItemServicoRPS(ptrDiscriminacaoServico,
                                        Quantidade,
                                        ValorUnitario,
                                        ptrTributavel);
            Marshal.FreeHGlobal(ptrDiscriminacaoServico);
            Marshal.FreeHGlobal(ptrTributavel);
            return erroRetorno;

        }


        //Função para passar os dados de cada item de dedução do RPS
        public int dllAdicionarDeducaoRPS(string DeducaoPor,
                                           string TipoDeducao,
                                           string CPFCNPJReferencia,
                                              int NumeroNFReferencia,
                                           double ValorTotalReferencia,
                                           double PercentualDeduzir,
                                           double ValorDeduzir)
        {
            IntPtr ptrDeducaoPor = Marshal.StringToHGlobalAnsi(DeducaoPor);
            IntPtr ptrTipoDeducao = Marshal.StringToHGlobalAnsi(TipoDeducao);
            IntPtr ptrCPFCNPJReferencia = Marshal.StringToHGlobalAnsi(CPFCNPJReferencia);
            int erroRetorno = AdicionarDeducaoRPS(ptrDeducaoPor,
                                       ptrTipoDeducao,
                                       ptrCPFCNPJReferencia,
                                       NumeroNFReferencia,
                                       ValorTotalReferencia,
                                       PercentualDeduzir,
                                       ValorDeduzir);
            //Libera Memoria
            Marshal.FreeHGlobal(ptrDeducaoPor);
            Marshal.FreeHGlobal(ptrTipoDeducao);
            Marshal.FreeHGlobal(ptrCPFCNPJReferencia);
            return erroRetorno;



        }

        public int dllEnviar(string DocAssinatura,
                            ref string Assincrono,
                            ref string Sucesso,
                               ref int NumeroLote,
                               ref int QtdNotasProcessadas,
                            ref double ValorTotalServicos,
                            ref double ValorTotalDeducoes,
                               ref int Erros,
                               ref int Alertas)
        {

            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);
            IntPtr ptrDocAssinatura = (IntPtr)Marshal.StringToHGlobalAnsi(DocAssinatura);
            StringBuilder sAssincrono = new StringBuilder(1);
            StringBuilder sSucesso = new StringBuilder(5);
            sSucesso.Append(Sucesso);

            int erroRetorno = Enviar(ptrDocAssinatura,
                                ref sAssincrono,
                                ref sSucesso,
                                ref NumeroLote,
                                ref QtdNotasProcessadas,
                                ref ValorTotalServicos,
                                ref ValorTotalDeducoes,
                                ref Erros,
                                ref Alertas);
            //Libera memoria
            Marshal.FreeHGlobal(ptrDocAssinatura);


            Assincrono = sAssincrono.ToString();
            Sucesso = sSucesso.ToString();
            return erroRetorno;



        }

        public int dllTesteEnviar(string DocAssinatura,
                                    ref string Assincrono,
                                    ref string Sucesso,
                                       ref int NumeroLote,
                                       ref int QtdNotasProcessadas,
                                    ref double ValorTotalServicos,
                                    ref double ValorTotalDeducoes,
                                       ref int Erros,
                                       ref int Alertas)
        {

            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);

            IntPtr ptrDocAssinatura = Marshal.StringToHGlobalAnsi(DocAssinatura);
            StringBuilder sAssincrono = new StringBuilder(1);
            StringBuilder sSucesso = new StringBuilder(5);
            sSucesso.Append(Sucesso);

            int erroRetorno = TesteEnviar(ptrDocAssinatura,
                                ref sAssincrono,
                                ref sSucesso,
                                ref NumeroLote,
                                ref QtdNotasProcessadas,
                                ref ValorTotalServicos,
                                ref ValorTotalDeducoes,
                                ref Erros,
                                ref Alertas);
            //Libera memoria
            Marshal.FreeHGlobal(ptrDocAssinatura);


            Assincrono = sAssincrono.ToString();
            Sucesso = sSucesso.ToString();
            return erroRetorno;



        }








        public int dllObterNotaRetorno(int RetornoItem,
                               ref string InscricaoPrestador,
                               ref int NumeroNFe,
                               ref string CodigoVerificacao,
                               ref string RazaoSocialPrestador,
                               ref string SerieRPS,
                               ref int NumeroRPS,
                               ref string DataEmissaoRPS)
        {

            StringBuilder sInscricaoPrestador = new StringBuilder(2000);
            StringBuilder sCodigoVerificacao = new StringBuilder(2000);
            StringBuilder sRazaoSocialPrestador = new StringBuilder(2000);
            StringBuilder sSerieRPS = new StringBuilder(2000);
            StringBuilder sDataEmissaoRPS = new StringBuilder(2000);


            int erroRetorno = ObterNotaRetorno(RetornoItem,
                                               ref sInscricaoPrestador,
                                               ref NumeroNFe,
                                               ref sCodigoVerificacao,
                                               ref sRazaoSocialPrestador,
                                               ref sSerieRPS,
                                               ref NumeroRPS,
                                               ref sDataEmissaoRPS);

            InscricaoPrestador = sInscricaoPrestador.ToString();
            CodigoVerificacao = sCodigoVerificacao.ToString();
            RazaoSocialPrestador = sRazaoSocialPrestador.ToString();
            SerieRPS = sSerieRPS.ToString();
            DataEmissaoRPS = sDataEmissaoRPS.ToString();

            return erroRetorno;

        }




        public int dllConsultarLote(int CodCidade,
                                  string CPFCNPJRemetente,
                                     int NumeroLote,
                              ref string Sucesso,
                              ref string DataEnvioLote,
                                 ref int QtdNotasProcessadas,
                              ref string TempoProcessamento,
                              ref double ValorTotalServicos,
                              ref double ValotTotalDeducoes,
                                 ref int Alertas,
                                 ref int Erros)
        {

            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);

            IntPtr ptrCPFCNPJRemetente = Marshal.StringToHGlobalAnsi(CPFCNPJRemetente);
            StringBuilder sSucesso = new StringBuilder(5);
            StringBuilder sDataEnvioLote = new StringBuilder(20);
            StringBuilder sTempoProcessamento = new StringBuilder(10);
            int erroRetorno = ConsultarLote(CodCidade,
                                            ptrCPFCNPJRemetente,
                                            NumeroLote,
                                        ref sSucesso,
                                        ref sDataEnvioLote,
                                        ref QtdNotasProcessadas,
                                        ref sTempoProcessamento,
                                        ref ValorTotalServicos,
                                        ref ValotTotalDeducoes,
                                        ref Alertas,
                                        ref Erros);



            Sucesso = sSucesso.ToString();
            DataEnvioLote = sDataEnvioLote.ToString();
            TempoProcessamento = sTempoProcessamento.ToString();


            //Libera memoria
            Marshal.FreeHGlobal(ptrCPFCNPJRemetente);
            return erroRetorno;
        }


        public int dllObterNotaDoConsultarLote(int NrItem,
                                         ref string InscricaoPrestador,
                                            ref int NumeroNFe,
                                         ref string CodigoVerificacao,
                                         ref string SerieRPS,
                                            ref int NumeroRPS,
                                         ref string DataEmissaoRPS,
                                         ref string RazaoSocialPrestador,
                                         ref string TipoRecolhimento,
                                         ref double ValorDeduzir,
                                         ref double ValorTotal,
                                         ref double Aliquota)
        {
            StringBuilder sInscricaoPrestador = new StringBuilder(20);
            StringBuilder sCodigoVerificacao = new StringBuilder(255);
            StringBuilder sSerieRPS = new StringBuilder(10);
            StringBuilder sDataEmissaoRPS = new StringBuilder(20);
            StringBuilder sRazaoSocialPrestador = new StringBuilder(200);
            StringBuilder sTipoRecolhimento = new StringBuilder(1);

            int erroRetorno = ObterNotaDoConsultarLote(NrItem,
                                            ref sInscricaoPrestador,
                                            ref NumeroNFe,
                                            ref sCodigoVerificacao,
                                            ref sSerieRPS,
                                            ref NumeroRPS,
                                            ref sDataEmissaoRPS,
                                            ref sRazaoSocialPrestador,
                                            ref sTipoRecolhimento,
                                            ref ValorDeduzir,
                                            ref ValorTotal,
                                            ref Aliquota);

            InscricaoPrestador = sInscricaoPrestador.ToString();
            CodigoVerificacao = sCodigoVerificacao.ToString();
            SerieRPS = sSerieRPS.ToString();
            DataEmissaoRPS = sDataEmissaoRPS.ToString();
            RazaoSocialPrestador = sRazaoSocialPrestador.ToString();
            TipoRecolhimento = sTipoRecolhimento.ToString();
            return erroRetorno;
        }





        public int dllConsultarNotasConvertidas(String DocAssinatura,
                                     int CodCidade,
                                  string CPFCNPJRemetente,
                                  string InscricaoMunicipalPrestador,
                                  string DataInicio,
                                  string DataTermino,
                                     int NotaInicial,
                                 ref int QtdNotas,
                                 ref int Erros)
        {

            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);


            IntPtr PtrCPFCNPJRemetente = Marshal.StringToHGlobalAnsi(CPFCNPJRemetente);
            IntPtr PtrInscricaoMunicipalPrestador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalPrestador);
            IntPtr PtrDataInicio = Marshal.StringToHGlobalAnsi(DataInicio);
            IntPtr PtrDataTermino = Marshal.StringToHGlobalAnsi(DataTermino);
            IntPtr PtrDocAssinatura = Marshal.StringToHGlobalAnsi(DocAssinatura);

            int erroRetorno = ConsultarNotasConvertidas(PtrDocAssinatura,
                                             CodCidade,
                                             PtrCPFCNPJRemetente,
                                             PtrInscricaoMunicipalPrestador,
                                             PtrDataInicio,
                                             PtrDataTermino,
                                             NotaInicial,
                                         ref QtdNotas,
                                         ref Erros);
            //Libera memoria
            Marshal.FreeHGlobal(PtrCPFCNPJRemetente);
            Marshal.FreeHGlobal(PtrInscricaoMunicipalPrestador);
            Marshal.FreeHGlobal(PtrDataInicio);
            Marshal.FreeHGlobal(PtrDataTermino);
            Marshal.FreeHGlobal(PtrDocAssinatura);
            return erroRetorno;
        }






        public int dllObterNotaDoConsultarNotasV1(int PosNotaConsulta, //Posição na lista de nota obtidas com a função ConsultarNotas. Se retornou 10 notas, setar na posição 0 a 9
                                            ref int NumeroNota,
                                         ref string DataProcessamento,
                                            ref int NumeroLote,
                                         ref string CodigoVerificacao,
                                         ref string Assinatura,
                                         ref string InscricaoMunicipalPrestador,
                                         ref string RazaoSocialPrestador,
                                         ref string TipoRPS,
                                         ref string SerieRPS,
                                            ref int NumeroRPS,
                                         ref string DataEmissaoRPS,
                                         ref string SituacaoRPS,
                                         ref string SerieRPSSubstituido,
                                            ref int NumeroRPSSubstituido,
                                            ref int NumeroNFSeSubstituida,
                                         ref string DataEmissaoNFSeSubstituida,
                                         ref string SeriePrestacao,
                                         ref string InscricaoMunicipalTomador,
                                         ref string CPFCNPJTomador,
                                         ref string RazaoSocialTomador,
                                         ref string DocTomadorEstrangeiro,
                                         ref string TipoLogradouroTomador,
                                         ref string LogradouroTomador,
                                         ref string NumeroEnderecoTomador,
                                         ref string ComplementoEnderecoTomador,
                                         ref string TipoBairroTomador,
                                         ref string BairroTomador,
                                         ref string CidadeTomador,
                                         ref string CidadeTomadorDescricao,
                                         ref string CEPTomador,
                                         ref string EmailTomador,
                                         ref string CodigoAtividade,
                                         ref double AliquotaAtividade,
                                         ref string TipoRecolhimento,
                                            ref int MunicipioPrestacao,
                                         ref string MunicipioPrestacaoDescricao,
                                         ref string Operacao,
                                         ref string Tributacao,
                                         ref double ValorPIS,
                                         ref double ValorCOFINS,
                                         ref double ValorINSS,
                                         ref double ValorIR,
                                         ref double ValorCSLL,
                                         ref double AliquotaPIS,
                                         ref double AliquotaCOFINS,
                                         ref double AliquotaINSS,
                                         ref double AliquotaIR,
                                         ref double AliquotaCSLL,
                                         ref string DescricaoRPS,
                                         ref string DDDPrestador,
                                         ref string TelefonePrestador,
                                         ref string DDDTomador,
                                         ref string TelefoneTomador,
                                         ref string MotCancelamento,
                                         ref string CpfCnpjIntermediario,
                                            ref int Deducoes,
                                            ref int Itens)
        {


            StringBuilder sDataProcessamento = new StringBuilder(20);

            StringBuilder sCodigoVerificacao = new StringBuilder(255);
            StringBuilder sAssinatura = new StringBuilder(255);
            StringBuilder sInscricaoMunicipalPrestador = new StringBuilder(20);
            StringBuilder sRazaoSocialPrestador = new StringBuilder(200);
            StringBuilder sTipoRPS = new StringBuilder(10);
            StringBuilder sSerieRPS = new StringBuilder(2);
            StringBuilder sDataEmissaoRPS = new StringBuilder(20);
            StringBuilder sSituacaoRPS = new StringBuilder(1);
            StringBuilder sSerieRPSSubstituido = new StringBuilder(10);

            StringBuilder sDataEmissaoNFSeSubstituida = new StringBuilder(20);
            StringBuilder sSeriePrestacao = new StringBuilder(2);
            StringBuilder sInscricaoMunicipalTomador = new StringBuilder(20);
            StringBuilder sCPFCNPJTomador = new StringBuilder(14);
            StringBuilder sRazaoSocialTomador = new StringBuilder(200);
            StringBuilder sDocTomadorEstrangeiro = new StringBuilder(20);
            StringBuilder sTipoLogradouroTomador = new StringBuilder(50);
            StringBuilder sLogradouroTomador = new StringBuilder(200);
            StringBuilder sNumeroEnderecoTomador = new StringBuilder(20);
            StringBuilder sComplementoEnderecoTomador = new StringBuilder(30);
            StringBuilder sTipoBairroTomador = new StringBuilder(20);
            StringBuilder sBairroTomador = new StringBuilder(100);
            StringBuilder sCidadeTomador = new StringBuilder(10);
            StringBuilder sCidadeTomadorDescricao = new StringBuilder(200);
            StringBuilder sCEPTomador = new StringBuilder(8);
            StringBuilder sEmailTomador = new StringBuilder(100);
            StringBuilder sCodigoAtividade = new StringBuilder(10);

            StringBuilder sTipoRecolhimento = new StringBuilder(1);
            StringBuilder sMunicipioPrestacaoDescricao = new StringBuilder(100);
            StringBuilder sOperacao = new StringBuilder(1);
            StringBuilder sTributacao = new StringBuilder(1);

            StringBuilder sDescricaoRPS = new StringBuilder(1500);
            StringBuilder sDDDPrestador = new StringBuilder(3);
            StringBuilder sTelefonePrestador = new StringBuilder(10);
            StringBuilder sDDDTomador = new StringBuilder(3);
            StringBuilder sTelefoneTomador = new StringBuilder(10);
            StringBuilder sMotCancelamento = new StringBuilder(100);
            StringBuilder sCpfCnpjIntermediario = new StringBuilder(14);


            int erroRetorno = ObterNotaDoConsultarNotasV1(PosNotaConsulta, //Posição na lista de nota obtidas com a função ConsultarNotas. Se retornou 10 notas, setar na posição 0 a 9
                                                      ref NumeroNota,
                                                      ref sDataProcessamento,
                                                      ref NumeroLote,
                                                      ref sCodigoVerificacao,
                                                      ref sAssinatura,
                                                      ref sInscricaoMunicipalPrestador,
                                                      ref sRazaoSocialPrestador,
                                                      ref sTipoRPS,
                                                      ref sSerieRPS,
                                                      ref NumeroRPS,
                                                      ref sDataEmissaoRPS,
                                                      ref sSituacaoRPS,
                                                      ref sSerieRPSSubstituido,
                                                      ref NumeroRPSSubstituido,
                                                      ref NumeroNFSeSubstituida,
                                                      ref sDataEmissaoNFSeSubstituida,
                                                      ref sSeriePrestacao,
                                                      ref sInscricaoMunicipalTomador,
                                                      ref sCPFCNPJTomador,
                                                      ref sRazaoSocialTomador,
                                                      ref sDocTomadorEstrangeiro,
                                                      ref sTipoLogradouroTomador,
                                                      ref sLogradouroTomador,
                                                      ref sNumeroEnderecoTomador,
                                                      ref sComplementoEnderecoTomador,
                                                      ref sTipoBairroTomador,
                                                      ref sBairroTomador,
                                                      ref sCidadeTomador,
                                                      ref sCidadeTomadorDescricao,
                                                      ref sCEPTomador,
                                                      ref sEmailTomador,
                                                      ref sCodigoAtividade,
                                                      ref AliquotaAtividade,
                                                      ref sTipoRecolhimento,
                                                      ref MunicipioPrestacao,
                                                      ref sMunicipioPrestacaoDescricao,
                                                      ref sOperacao,
                                                      ref sTributacao,
                                                      ref ValorPIS,
                                                      ref ValorCOFINS,
                                                      ref ValorINSS,
                                                      ref ValorIR,
                                                      ref ValorCSLL,
                                                      ref AliquotaPIS,
                                                      ref AliquotaCOFINS,
                                                      ref AliquotaINSS,
                                                      ref AliquotaIR,
                                                      ref AliquotaCSLL,
                                                      ref sDescricaoRPS,
                                                      ref sDDDPrestador,
                                                      ref sTelefonePrestador,
                                                      ref sDDDTomador,
                                                      ref sTelefoneTomador,
                                                      ref sMotCancelamento,
                                                      ref sCpfCnpjIntermediario,
                                                      ref Deducoes,
                                                      ref Itens);


            DataProcessamento = sDataProcessamento.ToString();
            CodigoVerificacao = sCodigoVerificacao.ToString();
            Assinatura = sAssinatura.ToString();
            InscricaoMunicipalPrestador = sInscricaoMunicipalPrestador.ToString();
            RazaoSocialPrestador = sRazaoSocialPrestador.ToString();
            TipoRPS = sTipoRPS.ToString();
            SerieRPS = sSerieRPS.ToString();
            DataEmissaoRPS = sDataEmissaoRPS.ToString();
            SituacaoRPS = sSituacaoRPS.ToString();
            SerieRPSSubstituido = sSerieRPSSubstituido.ToString();
            DataEmissaoNFSeSubstituida = sDataEmissaoNFSeSubstituida.ToString();
            SeriePrestacao = sSeriePrestacao.ToString();
            InscricaoMunicipalTomador = sInscricaoMunicipalTomador.ToString();
            CPFCNPJTomador = sCPFCNPJTomador.ToString();
            RazaoSocialTomador = sRazaoSocialTomador.ToString();
            DocTomadorEstrangeiro = sDocTomadorEstrangeiro.ToString();
            TipoLogradouroTomador = sTipoLogradouroTomador.ToString();
            LogradouroTomador = sLogradouroTomador.ToString();
            NumeroEnderecoTomador = sNumeroEnderecoTomador.ToString();
            ComplementoEnderecoTomador = sComplementoEnderecoTomador.ToString();
            TipoBairroTomador = sTipoBairroTomador.ToString();
            BairroTomador = sBairroTomador.ToString();
            CidadeTomador = sCidadeTomador.ToString();
            CidadeTomadorDescricao = sCidadeTomadorDescricao.ToString();
            CEPTomador = sCEPTomador.ToString();
            EmailTomador = sEmailTomador.ToString();
            CodigoAtividade = sCodigoAtividade.ToString();
            TipoRecolhimento = sTipoRecolhimento.ToString();
            MunicipioPrestacaoDescricao = sMunicipioPrestacaoDescricao.ToString();
            Operacao = sOperacao.ToString();
            Tributacao = sTributacao.ToString();
            DescricaoRPS = sDescricaoRPS.ToString();
            DDDPrestador = sDDDPrestador.ToString();
            TelefonePrestador = sTelefonePrestador.ToString();
            DDDTomador = sDDDTomador.ToString();
            TelefoneTomador = sTelefoneTomador.ToString();
            MotCancelamento = sMotCancelamento.ToString();
            CpfCnpjIntermediario = sCpfCnpjIntermediario.ToString();

            return erroRetorno;

        }





        public int dllObterDecucaoNota(int PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                       int PosDeducaoNotaConsulta,
                                ref string DeducaoPor,
                                ref string TipoDeducao,
                                ref string CPFCNPJReferencia,
                                   ref int NumeroNFReferencia,
                                ref double ValorTotalReferencia,
                                ref double PercentualDeduzir,
                                ref double ValorDeduzir)
        {

            StringBuilder sDeducaoPor = new StringBuilder(30);
            StringBuilder sTipoDeducao = new StringBuilder(40);
            StringBuilder sCPFCNPJReferencia = new StringBuilder(14);
            int erroRetorno = ObterDecucaoNota(PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                               PosDeducaoNotaConsulta,
                                               ref sDeducaoPor,
                                               ref sTipoDeducao,
                                               ref sCPFCNPJReferencia,
                                               ref NumeroNFReferencia,
                                               ref ValorTotalReferencia,
                                               ref PercentualDeduzir,
                                               ref ValorDeduzir);
            DeducaoPor = sDeducaoPor.ToString();
            TipoDeducao = sTipoDeducao.ToString();
            CPFCNPJReferencia = sCPFCNPJReferencia.ToString();
            return erroRetorno;
        }





        public int dllObterItemServicoNota(int PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                                          int PosItemNotaConsulta,
                                                   ref string DiscriminacaoServico,
                                                   ref double Quantidade,
                                                   ref double ValorUnitario,
                                                   ref double ValorTotal,
                                                   ref string Tributavel)
        {
            StringBuilder sDiscriminacaoServico = new StringBuilder(255);
            StringBuilder sTributavel = new StringBuilder(1);
            int erroRetorno = ObterItemServicoNota(PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                                   PosItemNotaConsulta,
                                               ref sDiscriminacaoServico,
                                               ref Quantidade,
                                               ref ValorUnitario,
                                               ref ValorTotal,
                                               ref sTributavel);
            DiscriminacaoServico = sDiscriminacaoServico.ToString();
            Tributavel = sTributavel.ToString();

            return erroRetorno;

        }
        public int dllObterErroConsultarNota(int ErroItem,
                                               ref int Codigo,
                                            ref string Descricao)
        {

            StringBuilder sDescricao = new StringBuilder(2000);


            int erroRetorno = ObterErroConsultarNota(ErroItem,
                                ref Codigo,
                                ref sDescricao);

            Descricao = sDescricao.ToString();

            return erroRetorno;
        }



        public int dllObterErroLote(int ErroItem,
                                               ref int Codigo,
                                            ref string Descricao,
                                            ref string InscricaoPrestador,
                                            ref string SerieRPS,
                                               ref int NumeroRPS,
                                            ref string DataEmissaoRPS,
                                            ref string RazaoSocialPrestador)
        {

            StringBuilder sDescricao = new StringBuilder(2000);
            StringBuilder sInscricaoPrestador = new StringBuilder(20);
            StringBuilder sSerieRPS = new StringBuilder(10);
            StringBuilder sDataEmissaoRPS = new StringBuilder(20);
            StringBuilder sRazaoSocialPrestador = new StringBuilder(200);


            int erroRetorno = ObterErroLote(ErroItem,
                                ref Codigo,
                                ref sDescricao,
                                ref sInscricaoPrestador,
                                ref sSerieRPS,
                                ref NumeroRPS,
                                ref sDataEmissaoRPS,
                                ref sRazaoSocialPrestador);

            Descricao = sDescricao.ToString();
            InscricaoPrestador = sInscricaoPrestador.ToString();
            SerieRPS = sSerieRPS.ToString();
            DataEmissaoRPS = sDataEmissaoRPS.ToString();
            RazaoSocialPrestador = sRazaoSocialPrestador.ToString();

            return erroRetorno;
        }




        public int dllObterAlertaLote(int ErroItem,
                                  ref int Codigo,
                               ref string Descricao,
                               ref string InscricaoPrestador,
                               ref string SerieRPS,
                                  ref int NumeroRPS,
                               ref string DataEmissaoRPS,
                               ref string RazaoSocialPrestador)
        {

            StringBuilder sDescricao = new StringBuilder(2000);
            StringBuilder sInscricaoPrestador = new StringBuilder(20);
            StringBuilder sSerieRPS = new StringBuilder(10);
            StringBuilder sDataEmissaoRPS = new StringBuilder(20);
            StringBuilder sRazaoSocialPrestador = new StringBuilder(200);

            int erroRetorno = ObterAlertaLote(ErroItem,
                               ref Codigo,
                               ref sDescricao,
                               ref sInscricaoPrestador,
                               ref sSerieRPS,
                               ref NumeroRPS,
                               ref sDataEmissaoRPS,
                               ref sRazaoSocialPrestador);

            Descricao = sDescricao.ToString();
            InscricaoPrestador = sInscricaoPrestador.ToString();
            SerieRPS = sSerieRPS.ToString();
            DataEmissaoRPS = sDataEmissaoRPS.ToString();
            RazaoSocialPrestador = sRazaoSocialPrestador.ToString();
            return erroRetorno;

        }





        public int dllCriarLoteCancelamento(int CodCidade,
                                         string CPFCNPJRemetente,
                                         string RazaoSocialRemetente)
        {
            IntPtr PtrCPFCNPJRemetente = Marshal.StringToHGlobalAnsi(CPFCNPJRemetente);
            IntPtr PtrRazaoSocialRemetente = Marshal.StringToHGlobalAnsi(RazaoSocialRemetente);
            int erroRetorno = CriarLoteCancelamento(CodCidade,
                                                    PtrCPFCNPJRemetente,
                                                    PtrRazaoSocialRemetente);
            //Libera memoria
            Marshal.FreeHGlobal(PtrCPFCNPJRemetente);
            Marshal.FreeHGlobal(PtrRazaoSocialRemetente);
            return erroRetorno;
        }


        //ADICIONA NOTA AO LOTE DE CANCELAMENTO DE NOTA FISCAL CRIADO NA FUNÇÃO ANTERIOR
        public int dllAdicionarNotaCancelamento(string InscricaoMunicipalPrestador,
                                                   int NumeroNota,
                                                string CodigoVerificacao,
                                                string MotivoCancelamento)
        {
            IntPtr PtrInscricaoMunicipalPrestador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalPrestador);
            IntPtr PtrCodigoVerificacao = Marshal.StringToHGlobalAnsi(CodigoVerificacao);
            IntPtr PtrMotivoCancelamento = Marshal.StringToHGlobalAnsi(MotivoCancelamento);
            int erroRetorno = AdicionarNotaCancelamento(PtrInscricaoMunicipalPrestador,
                                                         NumeroNota,
                                                         PtrCodigoVerificacao,
                                                         PtrMotivoCancelamento);
            Marshal.FreeHGlobal(PtrInscricaoMunicipalPrestador);
            Marshal.FreeHGlobal(PtrCodigoVerificacao);
            Marshal.FreeHGlobal(PtrMotivoCancelamento);
            return erroRetorno;
        }


        public int dllEnviarCancelamento(string pDocAssinatura,
                                      ref string pSucesso,
                                         ref int pQtdNotasCanceladas,
                                         ref int pErros,
                                         ref int pAlertas)
        {
            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);

            IntPtr PtrDocAssinatura = Marshal.StringToHGlobalAnsi(pDocAssinatura);
            StringBuilder sSucesso = new StringBuilder(10);
            int erroRetorno = EnviarCancelamento(PtrDocAssinatura,
                                          ref sSucesso,
                                                    ref pQtdNotasCanceladas,
                                                    ref pErros,
                                                    ref pAlertas);
            pSucesso = sSucesso.ToString();
            Marshal.FreeHGlobal(PtrDocAssinatura);
            return erroRetorno;


        }

        public int dllObterNotaRetornoCancelamento(int RetornoItem, //Posição da lista de notas canceladas retornadas
                                            ref string pInscricaoPrestador,
                                               ref int pNumeroNota,
                                            ref string pCodigoVerificacao)
        {
            StringBuilder sInscricaoPrestador = new StringBuilder(20);
            StringBuilder sCodigoVerificacao = new StringBuilder(200);
            int erroRetorno = ObterNotaRetornoCancelamento(RetornoItem, //Posição da lista de notas canceladas retornadas
                                                 ref sInscricaoPrestador,
                                                 ref pNumeroNota,
                                                 ref sCodigoVerificacao);
            pInscricaoPrestador = sInscricaoPrestador.ToString();
            pCodigoVerificacao = sCodigoVerificacao.ToString();
            return erroRetorno;
        }

        //FUNÇÃO PARA OBTER OS ERROS NO CANCELAMENTO, OBTÉM O RETORNO DO ENVIARCANCELAMENTO
        //Por exemplo se no parâmetro de retorno pErros do EnviarCancelamento retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro ErroItem a pósição .

        public int dllObterErroLoteCancelamento(int ErroItem,
                                            ref int pCodigo,
                                         ref string pDescricao,
                                         ref string pInscricaoPrestador,
                                            ref int pNumeroNFe,
                                         ref string pCodigoVerificacao)
        {
            StringBuilder sDescricao = new StringBuilder(2000);
            StringBuilder sInscricaoPrestador = new StringBuilder(20);
            StringBuilder sCodigoVerificacao = new StringBuilder(200);
            int erroRetorno = ObterErroLoteCancelamento(ErroItem,
                                                        ref pCodigo,
                                              ref sDescricao,
                                              ref sInscricaoPrestador,
                                              ref pNumeroNFe,
                                              ref sCodigoVerificacao);
            pDescricao = sDescricao.ToString();
            pInscricaoPrestador = sInscricaoPrestador.ToString();
            pCodigoVerificacao = sCodigoVerificacao.ToString();
            return erroRetorno;
        }
        //FUNÇÃO PARA OBTER OS ALERTAS NO CANCELAMENTO, OBTÉM O RETORNO DO ENVIARCANCELAMENTO
        //Por exemplo se no parâmetro de retorno pAlertas do EnviarCancelamento retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro AlertaItem a pósição .



        public int dllObterAlertaLoteCancelamento(int AlertaItem,
                                              ref int pCodigo,
                                           ref string pDescricao,
                                           ref string pInscricaoPrestador,
                                              ref int pNumeroNFe,
                                           ref string pCodigoVerificacao)
        {
            StringBuilder sDescricao = new StringBuilder(2000);
            StringBuilder sInscricaoPrestador = new StringBuilder(20);
            StringBuilder sCodigoVerificacao = new StringBuilder(200);
            int erroRetorno = ObterAlertaLoteCancelamento(AlertaItem,
                                                          ref pCodigo,
                                                ref sDescricao,
                                                ref sInscricaoPrestador,
                                                          ref  pNumeroNFe,
                                                ref sCodigoVerificacao);
            pDescricao = sDescricao.ToString();
            pInscricaoPrestador = sInscricaoPrestador.ToString();
            pCodigoVerificacao = sCodigoVerificacao.ToString();
            return erroRetorno;



        }


        //FUNÇÃO DO CONSULTAR NFSE OU RPS
        public int dllCriarLoteConsultaNFSeRPS(int CodCidade,
                                            string CPFCNPJRemetente,
                                            string RazaoSocialRemetente)
        {
            IntPtr PtrCPFCNPJRemetente = Marshal.StringToHGlobalAnsi(CPFCNPJRemetente);
            IntPtr PtrRazaoSocialRemetente = Marshal.StringToHGlobalAnsi(RazaoSocialRemetente);
            int erroRetorno = CriarLoteConsultaNFSeRPS(CodCidade,
                                                       PtrCPFCNPJRemetente,
                                                       PtrRazaoSocialRemetente);
            //Libera memoria
            Marshal.FreeHGlobal(PtrCPFCNPJRemetente);
            Marshal.FreeHGlobal(PtrRazaoSocialRemetente);
            return erroRetorno;
        }


        //ADICIONA NOTA A CONSULTA NFSE OU RPS
        public int dllAdicionarNFSeConsultaNFSeRPS(string InscricaoMunicipalPrestador,
                                                      int NumeroNota,
                                                   string CodigoVerificacao)
        {
            IntPtr PtrInscricaoMunicipalPrestador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalPrestador);
            IntPtr PtrCodigoVerificacao = Marshal.StringToHGlobalAnsi(CodigoVerificacao);

            int erroRetorno = AdicionarNFSeConsultaNFSeRPS(PtrInscricaoMunicipalPrestador,
                                                           NumeroNota,
                                                           PtrCodigoVerificacao);
            Marshal.FreeHGlobal(PtrInscricaoMunicipalPrestador);
            Marshal.FreeHGlobal(PtrCodigoVerificacao);

            return erroRetorno;
        }


        //ADICIONA RPS A CONSULTA NFSE OU RPS
        public int dllAdicionarRPSConsultaNFSeRPS(string InscricaoMunicipalPrestador,
                                                     int NumeroRps,
                                                  string SeriePrestacao)
        {
            IntPtr PtrInscricaoMunicipalPrestador = Marshal.StringToHGlobalAnsi(InscricaoMunicipalPrestador);
            IntPtr PtrSeriePrestacao = Marshal.StringToHGlobalAnsi(SeriePrestacao);

            int erroRetorno = AdicionarRPSConsultaNFSeRPS(PtrInscricaoMunicipalPrestador,
                                                          NumeroRps,
                                                          PtrSeriePrestacao);
            Marshal.FreeHGlobal(PtrInscricaoMunicipalPrestador);
            Marshal.FreeHGlobal(PtrSeriePrestacao);

            return erroRetorno;
        }

        //Gera o Xml da Consulta de NFSe ou RPS e envia para o web service retornado as informações
        public int dllEnviarConsultaNFSeRPS(string pDocAssinatura,
                                         ref string pSucesso,
                                            ref int pQtdNotasConsultaNFSe,
                                            ref int pErros,
                                            ref int pAlertas)
        {
            //Aponta o endereço do ambiente, o endereço do ambiente de produção ou homologação encontram-se especificados no manual da DLL.
            dllSetURL(this.url1, this.url2);

            IntPtr PtrDocAssinatura = Marshal.StringToHGlobalAnsi(pDocAssinatura);
            StringBuilder sSucesso = new StringBuilder(10);
            int erroRetorno = EnviarConsultaNFSeRPS(PtrDocAssinatura,
                                                ref sSucesso,
                                                ref pQtdNotasConsultaNFSe,
                                                ref pErros,
                                                ref pAlertas);
            pSucesso = sSucesso.ToString();
            Marshal.FreeHGlobal(PtrDocAssinatura);
            return erroRetorno;


        }

        public int dllObterNotaRetornoNFSeRPSV1(int PosNotaConsultaNFSeRPS, //Posição da lista de notas retornadas
                                          ref int pNumeroNota,
                                       ref string pDataProcessamento,
                                          ref int pNumeroLote,
                                       ref string pCodigoVerificacao,
                                       ref string pAssinatura,
                                       ref string pInscricaoMunicipalPrestador,
                                       ref string pRazaoSocialPrestador,
                                       ref string pTipoRPS,
                                       ref string pSerieRPS,
                                          ref int pNumeroRPS,
                                       ref string pDataEmissaoRPS,
                                       ref string pSituacaoRPS,
                                       ref string pSerieRPSSubstituido,
                                          ref int pNumeroRPSSubstituido,
                                          ref int pNumeroNFSeSubstituida,
                                       ref string pDataEmissaoNFSeSubstituida,
                                       ref string pSeriePrestacao,
                                       ref string pInscricaoMunicipalTomador,
                                       ref string pCPFCNPJTomador,
                                       ref string pRazaoSocialTomador,
                                       ref string pDocTomadorEstrangeiro,
                                       ref string pTipoLogradouroTomador,
                                       ref string pLogradouroTomador,
                                       ref string pNumeroEnderecoTomador,
                                       ref string pComplementoEnderecoTomador,
                                       ref string pTipoBairroTomador,
                                       ref string pBairroTomador,
                                       ref string pCidadeTomador,
                                       ref string pCidadeTomadorDescricao,
                                       ref string pCEPTomador,
                                       ref string pEmailTomador,
                                       ref string pCodigoAtividade,
                                       ref double pAliquotaAtividade,
                                       ref string pTipoRecolhimento,
                                          ref int pMunicipioPrestacao,
                                       ref string pMunicipioPrestacaoDescricao,
                                       ref string pOperacao,
                                       ref string pTributacao,
                                       ref double pValorPIS,
                                       ref double pValorCOFINS,
                                       ref double pValorINSS,
                                       ref double pValorIR,
                                       ref double pValorCSLL,
                                       ref double pAliquotaPIS,
                                       ref double pAliquotaCOFINS,
                                       ref double pAliquotaINSS,
                                       ref double pAliquotaIR,
                                       ref double pAliquotaCSLL,
                                       ref string pDescricaoRPS,
                                       ref string pDDDPrestador,
                                       ref string pTelefonePrestador,
                                       ref string pDDDTomador,
                                       ref string pTelefoneTomador,
                                       ref string pMotCancelamento,
                                       ref string pCpfCnpjIntermediario,
                                          ref int pDeducoes,
                                          ref int pItens)
        {
            StringBuilder sDataProcessamento = new StringBuilder(20);
            StringBuilder sCodigoVerificacao = new StringBuilder(255);
            StringBuilder sAssinatura = new StringBuilder(255);
            StringBuilder sInscricaoMunicipalPrestador = new StringBuilder(20);
            StringBuilder sRazaoSocialPrestador = new StringBuilder(200);
            StringBuilder sTipoRPS = new StringBuilder(10);
            StringBuilder sSerieRPS = new StringBuilder(2);
            StringBuilder sDataEmissaoRPS = new StringBuilder(20);
            StringBuilder sSituacaoRPS = new StringBuilder(1);
            StringBuilder sSerieRPSSubstituido = new StringBuilder(10);
            StringBuilder sDataEmissaoNFSeSubstituida = new StringBuilder(20);
            StringBuilder sSeriePrestacao = new StringBuilder(2);
            StringBuilder sInscricaoMunicipalTomador = new StringBuilder(20);
            StringBuilder sCPFCNPJTomador = new StringBuilder(14);
            StringBuilder sRazaoSocialTomador = new StringBuilder(200);
            StringBuilder sDocTomadorEstrangeiro = new StringBuilder(20);
            StringBuilder sTipoLogradouroTomador = new StringBuilder(50);
            StringBuilder sLogradouroTomador = new StringBuilder(200);
            StringBuilder sNumeroEnderecoTomador = new StringBuilder(20);
            StringBuilder sComplementoEnderecoTomador = new StringBuilder(30);
            StringBuilder sTipoBairroTomador = new StringBuilder(20);
            StringBuilder sBairroTomador = new StringBuilder(100);
            StringBuilder sCidadeTomador = new StringBuilder(10);
            StringBuilder sCidadeTomadorDescricao = new StringBuilder(200);
            StringBuilder sCEPTomador = new StringBuilder(8);
            StringBuilder sEmailTomador = new StringBuilder(100);
            StringBuilder sCodigoAtividade = new StringBuilder(10);
            StringBuilder sTipoRecolhimento = new StringBuilder(1);
            StringBuilder sMunicipioPrestacaoDescricao = new StringBuilder(100);
            StringBuilder sOperacao = new StringBuilder(1);
            StringBuilder sTributacao = new StringBuilder(1);
            StringBuilder sDescricaoRPS = new StringBuilder(1500);
            StringBuilder sDDDPrestador = new StringBuilder(3);
            StringBuilder sTelefonePrestador = new StringBuilder(10);
            StringBuilder sDDDTomador = new StringBuilder(3);
            StringBuilder sTelefoneTomador = new StringBuilder(10);
            StringBuilder sMotCancelamento = new StringBuilder(100);
            StringBuilder sCpfCnpjIntermediario = new StringBuilder(14);

            int erroRetorno = ObterNotaRetornoNFSeRPSV1(PosNotaConsultaNFSeRPS, //Posição na lista de nota obtidas com a função ConsultarNFSeRPS. Se retornou 10 notas, setar na posição 0 a 9
                                                   ref pNumeroNota,
                                                   ref sDataProcessamento,
                                                   ref pNumeroLote,
                                                   ref sCodigoVerificacao,
                                                   ref sAssinatura,
                                                   ref sInscricaoMunicipalPrestador,
                                                   ref sRazaoSocialPrestador,
                                                   ref sTipoRPS,
                                                   ref sSerieRPS,
                                                   ref pNumeroRPS,
                                                   ref sDataEmissaoRPS,
                                                   ref sSituacaoRPS,
                                                   ref sSerieRPSSubstituido,
                                                   ref pNumeroRPSSubstituido,
                                                   ref pNumeroNFSeSubstituida,
                                                   ref sDataEmissaoNFSeSubstituida,
                                                   ref sSeriePrestacao,
                                                   ref sInscricaoMunicipalTomador,
                                                   ref sCPFCNPJTomador,
                                                   ref sRazaoSocialTomador,
                                                   ref sDocTomadorEstrangeiro,
                                                   ref sTipoLogradouroTomador,
                                                   ref sLogradouroTomador,
                                                   ref sNumeroEnderecoTomador,
                                                   ref sComplementoEnderecoTomador,
                                                   ref sTipoBairroTomador,
                                                   ref sBairroTomador,
                                                   ref sCidadeTomador,
                                                   ref sCidadeTomadorDescricao,
                                                   ref sCEPTomador,
                                                   ref sEmailTomador,
                                                   ref sCodigoAtividade,
                                                   ref pAliquotaAtividade,
                                                   ref sTipoRecolhimento,
                                                   ref pMunicipioPrestacao,
                                                   ref sMunicipioPrestacaoDescricao,
                                                   ref sOperacao,
                                                   ref sTributacao,
                                                   ref pValorPIS,
                                                   ref pValorCOFINS,
                                                   ref pValorINSS,
                                                   ref pValorIR,
                                                   ref pValorCSLL,
                                                   ref pAliquotaPIS,
                                                   ref pAliquotaCOFINS,
                                                   ref pAliquotaINSS,
                                                   ref pAliquotaIR,
                                                   ref pAliquotaCSLL,
                                                   ref sDescricaoRPS,
                                                   ref sDDDPrestador,
                                                   ref sTelefonePrestador,
                                                   ref sDDDTomador,
                                                   ref sTelefoneTomador,
                                                   ref sMotCancelamento,
                                                   ref sCpfCnpjIntermediario,
                                                   ref pDeducoes,
                                                   ref pItens);


            pDataProcessamento = sDataProcessamento.ToString();
            pCodigoVerificacao = sCodigoVerificacao.ToString();
            pAssinatura = sAssinatura.ToString();
            pInscricaoMunicipalPrestador = sInscricaoMunicipalPrestador.ToString();
            pRazaoSocialPrestador = sRazaoSocialPrestador.ToString();
            pTipoRPS = sTipoRPS.ToString();
            pSerieRPS = sSerieRPS.ToString();
            pDataEmissaoRPS = sDataEmissaoRPS.ToString();
            pSituacaoRPS = sSituacaoRPS.ToString();
            pSerieRPSSubstituido = sSerieRPSSubstituido.ToString();
            pDataEmissaoNFSeSubstituida = sDataEmissaoNFSeSubstituida.ToString();
            pSeriePrestacao = sSeriePrestacao.ToString();
            pInscricaoMunicipalTomador = sInscricaoMunicipalTomador.ToString();
            pCPFCNPJTomador = sCPFCNPJTomador.ToString();
            pRazaoSocialTomador = sRazaoSocialTomador.ToString();
            pDocTomadorEstrangeiro = sDocTomadorEstrangeiro.ToString();
            pTipoLogradouroTomador = sTipoLogradouroTomador.ToString();
            pLogradouroTomador = sLogradouroTomador.ToString();
            pNumeroEnderecoTomador = sNumeroEnderecoTomador.ToString();
            pComplementoEnderecoTomador = sComplementoEnderecoTomador.ToString();
            pTipoBairroTomador = sTipoBairroTomador.ToString();
            pBairroTomador = sBairroTomador.ToString();
            pCidadeTomador = sCidadeTomador.ToString();
            pCidadeTomadorDescricao = sCidadeTomadorDescricao.ToString();
            pCEPTomador = sCEPTomador.ToString();
            pEmailTomador = sEmailTomador.ToString();
            pCodigoAtividade = sCodigoAtividade.ToString();
            pTipoRecolhimento = sTipoRecolhimento.ToString();
            pMunicipioPrestacaoDescricao = sMunicipioPrestacaoDescricao.ToString();
            pOperacao = sOperacao.ToString();
            pTributacao = sTributacao.ToString();
            pDescricaoRPS = sDescricaoRPS.ToString();
            pDDDPrestador = sDDDPrestador.ToString();
            pTelefonePrestador = sTelefonePrestador.ToString();
            pDDDTomador = sDDDTomador.ToString();
            pTelefoneTomador = sTelefoneTomador.ToString();
            pMotCancelamento = sMotCancelamento.ToString();
            pCpfCnpjIntermediario = sCpfCnpjIntermediario.ToString();

            return erroRetorno;
        }



        public int dllObterDecucaoNFSeRPS(int PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaRetornoNFSeRPS
                                          int PosDeducaoNotaConsulta,
                                   ref string DeducaoPor,
                                   ref string TipoDeducao,
                                   ref string CPFCNPJReferencia,
                                      ref int NumeroNFReferencia,
                                   ref double ValorTotalReferencia,
                                   ref double PercentualDeduzir,
                                   ref double ValorDeduzir)
        {

            StringBuilder sDeducaoPor = new StringBuilder(30);
            StringBuilder sTipoDeducao = new StringBuilder(40);
            StringBuilder sCPFCNPJReferencia = new StringBuilder(14);
            int erroRetorno = ObterDecucaoNFSeRPS(PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaRetornoNFSeRPS
                                                   PosDeducaoNotaConsulta,
                                               ref sDeducaoPor,
                                               ref sTipoDeducao,
                                               ref sCPFCNPJReferencia,
                                               ref NumeroNFReferencia,
                                               ref ValorTotalReferencia,
                                               ref PercentualDeduzir,
                                               ref ValorDeduzir);
            DeducaoPor = sDeducaoPor.ToString();
            TipoDeducao = sTipoDeducao.ToString();
            CPFCNPJReferencia = sCPFCNPJReferencia.ToString();
            return erroRetorno;
        }





        public int dllObterItemServicoNFSeRPS(int PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                                          int PosItemNotaConsulta,
                                                   ref string DiscriminacaoServico,
                                                   ref double Quantidade,
                                                   ref double ValorUnitario,
                                                   ref double ValorTotal,
                                                   ref string Tributavel)
        {
            StringBuilder sDiscriminacaoServico = new StringBuilder(255);
            StringBuilder sTributavel = new StringBuilder(1);
            int erroRetorno = ObterItemServicoNFSeRPS(PosNotaConsulta, //Deve ter o mesmo valor do parâmetro PosNotaConsulta  passado na função ObterNotaDoConsultarNotas
                                                   PosItemNotaConsulta,
                                               ref sDiscriminacaoServico,
                                               ref Quantidade,
                                               ref ValorUnitario,
                                               ref ValorTotal,
                                               ref sTributavel);
            DiscriminacaoServico = sDiscriminacaoServico.ToString();
            Tributavel = sTributavel.ToString();

            return erroRetorno;

        }

        //FUNÇÃO PARA OBTER OS ERROS DA CONSULTA NFSE OU RPS, OBTÉM O RETORNO DO EnviarConsultaNFSeRPS
        //Por exemplo se no parâmetro de retorno pErros do EnviarConsultaNFSeRPS retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro ErroItem a pósição .

        public int dllObterErroConsultaNFSeRPS(int ErroItem,
                                            ref int pCodigo,
                                         ref string pDescricao)
        {
            StringBuilder sDescricao = new StringBuilder(2000);

            int erroRetorno = ObterErroConsultaNFSeRPS(ErroItem,
                                                   ref pCodigo,
                                                   ref sDescricao);
            pDescricao = sDescricao.ToString();
            return erroRetorno;
        }
        //FUNÇÃO PARA OBTER OS ALERTAS DA CONSULTA NFSE OU RPS, OBTÉM O RETORNO DO EnviarConsultaNFSeRPS
        //Por exemplo se no parâmetro de retorno pAlertas do EnviarConsultaNFSeRPS retorna o valor 5,  deve-se
        // fazer um loop de 0 a 4 fazendo chamada a esta função passando no parametro AlertaItem a posição .



        public int dllObterAlertaConsultaNFSeRPS(int AlertaItem,
                                              ref int pCodigo,
                                           ref string pDescricao)
        {
            StringBuilder sDescricao = new StringBuilder(2000);

            int erroRetorno = ObterAlertaConsultaNFSeRPS(AlertaItem,
                                                      ref pCodigo,
                                                      ref sDescricao);
            pDescricao = sDescricao.ToString();
            return erroRetorno;



        }




        // Destructor
        Principal()
        {
            // Some resource cleanup routines
        }
    }
}
