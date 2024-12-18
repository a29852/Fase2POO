using BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    /// <summary>
    /// A classe Alojamentos gerencia os dados relacionados aos alojamentos
    /// </summary>
    public class Alojamentos
    {
        #region ATRIBUTOS

        /// <summary>
        /// Lista de alojamentos registados
        /// </summary>
        static List<Alojamento> alojamentos;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor static que inicializa a lista de alojamentos
        /// </summary>
        static Alojamentos()
        {
            alojamentos = new List<Alojamento>();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Compara se o alojamento já está registado na lista
        /// </summary>
        /// <param name="a">Objeto Alojamento a ser comparado</param>
        /// <returns>Retorna true se o alojamento já existe na lista</returns>
        public static bool CompararAlojamento(Alojamento a)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (a.Equals(alojamento))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Regista um novo alojamento na lista
        /// </summary>
        /// <param name="a">Alojamento a ser registado</param>
        /// <returns>Retorna true se o alojamento for registado com sucesso</returns>
        public static bool RegistarAlojamentos(Alojamento a)
        {
            try
            {
                alojamentos.Add(a);
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 | Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Pesquisa um alojamento pelo seu número e retorna o Alojamento correspondente
        /// </summary>
        /// <param name="numero">Número do alojamento a ser pesquisado</param>
        /// <returns>Retorna o Alojamento correspondente ou null se não encontrar</returns>
        public static Alojamento PequisarAlojamento(int numero)
        {
            try
            {
                foreach (Alojamento alojamento in alojamentos)
                {
                    if (alojamento.Numero == numero)
                    {
                        return alojamento;
                    }
                }
                return null;
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException("400 | Erro: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new IOException("500 |Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 |Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os alojamentos ordenados por número
        /// </summary>
        /// <returns>Lista de todos os alojamentos</returns>
        public static List<Alojamento> TodosAlojamentos()
        {
            try
            {
                alojamentos.Sort();
                List<Alojamento> lista = new List<Alojamento>();
                foreach (Alojamento a in alojamentos)
                {
                    lista.Add(new Alojamento(a.Numero, a.Tipo, a.Localizacao,a.PrecoNoite, a.Disponivel));
                }
                return lista;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 |Erro: " + ex.Message);
            }
        }


        /// <summary>
        /// Guarda os dados dos alojamentos em um ficheiro binário no caminho especificado
        /// </summary>
        /// <param name="pasta">Caminho da pasta onde o ficheiro será guardado</param>
        /// <returns>Retorna true se os dados forem guardados com sucesso</returns>
        public static bool GuardaAlojamentos(string pasta)
        {
            try
            {
                Stream stream = File.Open(pasta + "\\Alojamentos.bin", FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, alojamentos);
                stream.Close();
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }

        }

        /// <summary>
        /// Carrega os dados dos alojamentos a partir de um ficheiro binário no caminho especificado
        /// </summary>
        /// <param name="pasta">Caminho da pasta onde o ficheiro está</param>
        /// <returns>Retorna true se os dados forem carregados com sucesso</returns>
        public static bool CarregaAlojamentos(string pasta)
        {
            try
            {
                Stream stream = File.Open(pasta + "\\Alojamentos.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                alojamentos = (List<Alojamento>)bin.Deserialize(stream);
                stream.Close();
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }

        }

        #endregion
    }
}
