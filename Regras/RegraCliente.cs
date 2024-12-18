using BO;
using Dados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Regras
{
    /// <summary>
    /// Classe responsável por fornecer as regras de negócio
    /// Contém métodos que interagem com a camada de dados para gerir os clientes
    /// </summary>
    public class RegraCliente 
    {
        /// <summary>
        /// Tenta registar um novo cliente no sistema, verificando se ele já existe
        /// </summary>
        /// <param name="c">O cliente a ser registado</param>
        /// <returns>Retorna true se o cliente foi registado com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static bool TentaRegistarCliente(Cliente c)
        {
            
            try
            {
               
                if (!Clientes.CompararCliente(c))
                {
                    Clientes.RegistarCliente(c);
                    return true;
                }
                return false;
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
        /// Tenta pesquisar um cliente pelo id
        /// </summary>
        /// <param name="id">O id do cliente a ser pesquisado</param>
        /// <returns>Retorna o cliente encontrado</returns>
        /// <exception cref="ArgumentException">Lançada se o id do cliente for inválido</exception>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="ApplicationException">Lançada quando ocorre um erro genérico</exception>
        public static Cliente TentaPequisarCliente(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Clientes.PequisarCliente(id);
                }
                throw new ArgumentException("400");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("400 | Erro: " + ex.Message);
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
        /// Tenta obter todos os clientes
        /// </summary>
        /// <returns>Retorna uma lista de todos os clientes</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static List<Cliente> TentaTodosClientes()
        {
            try
            {
                return Clientes.TodosClientes();
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
        /// Tenta guardar todos os clientes em uma pasta especificada
        /// </summary>
        /// <param name="pasta">O caminho da pasta onde os clientes serão guradados</param>
        /// <returns>Retorna true se os clientes foram salvos com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        public static bool TentaGuardaClientes(string pasta)
        {
            try
            {
                return Clientes.GuardaClientes(pasta);

            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Tenta carregar os clientes a partir de um ficheiro binário localizado na pasta especificada
        /// </summary>
        /// <param name="pasta">O caminho da pasta onde o ficheiro de clientes está localizado</param>
        /// <returns>Retorna true se os clientes foram carregados com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        public static bool TentaCarregaClientes(string pasta)
        {
            try
            {
                if (File.Exists(pasta + "\\Clientes.bin"))
                {
                    return Clientes.CarregaClientes(pasta);
                }
                return false;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }

        }

    }
}
