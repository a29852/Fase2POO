using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Dados
{
    /// <summary>
    /// A classe Clientes gerencia os dados relacionados aos clientes
    /// </summary>
    public class Clientes
    {
        #region ATRIBUTOS

        /// <summary>
        /// Lista de clientes registados
        /// </summary>
        static List<Cliente> clientes;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor static que inicializa a lista de clientes
        /// </summary>
        static Clientes()
        {
            clientes = new List<Cliente>();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Compara se o cliente já está registado na lista
        /// </summary>
        /// <param name="c">Objeto Cliente a ser comparado</param>
        /// <returns>Retorna true se o cliente já existe na lista</returns>
        public static bool CompararCliente(Cliente c)
        {
            foreach (Cliente cliente in clientes)
            {
                if (c.Equals(cliente))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Regista um novo cliente na lista
        /// </summary>
        /// <param name="c">Cliente a ser registado</param>
        /// <returns>Retorna true se o cliente for registado com sucesso</returns>
        public static bool RegistarCliente(Cliente c)
        {
            if (c.Id <= 0 || string.IsNullOrEmpty(c.Nome) || c.Idade <= 0 || (c.Sexo != "M" && c.Sexo != "F"))
            {
                return false;
            }
            try
            {
                clientes.Add(c);
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
        /// Pesquisa um cliente pelo seu Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Retorna o cliente com o Id fornecido</returns>
        public static Cliente PequisarCliente(int id)
        {
            try
            {
                foreach (Cliente cliente in clientes)
                {
                    if (cliente.Id == id)
                    {
                        return cliente;
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
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 | Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        /// <returns>Lista de todos os clientes de forma ordenada</returns>
        public static List<Cliente> TodosClientes()
        {
            try
            {
                clientes.Sort();
                List<Cliente> lista = new List<Cliente>();
                foreach (Cliente c in clientes)
                {
                    lista.Add(new Cliente(c.Id, c.Nome, c.Contacto, c.Idade, c.Sexo));
                }
                return lista;
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
        /// Guarda a lista de clientes num ficheiro binário na pasta especificada
        /// </summary>
        /// <param name="pasta">Caminho da pasta onde o ficheiro será guardado</param>
        /// <returns>Retorna true se os dados forem guardados com sucesso</returns>
        public static bool GuardaClientes(string pasta)
        {
            try
            {
                Stream stream = File.Open(pasta + "\\Clientes.bin", FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, clientes);
                stream.Close();
                return true;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }

        }

        /// <summary>
        /// Carrega a lista de clientes a partir de um ficheiro binário
        /// </summary>
        /// <param name="pasta">Caminho da pasta onde o ficheiro está armazenado</param>
        /// <returns>Retorna true se os dados forem carregados com sucesso</returns>
        public static bool CarregaClientes(string pasta)
        {
            try
            {
                Stream stream = File.Open(pasta + "\\Clientes.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                clientes = (List<Cliente>)bin.Deserialize(stream);
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
