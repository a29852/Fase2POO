using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BO
{
    /// <summary>
    /// Representa um cliente no sistema onde o mesmo herda as características básicas de uma pessoa
    /// A classe armazena informações como id, nome, contacto, idade e sexo
    /// Implementa a interface IComparable para permitir a comparação entre objetos do tipo Cliente
    /// </summary>
    [Serializable]
    public class Cliente : Pessoa, IInterfaces, IComparable<Cliente>
    {
        #region ATRIBUTOS

        /// <summary>
        /// Atributos da classe Cliente
        /// </summary>

        int id;
        string nome;
        int contacto;

        #endregion


        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa uma nova instância
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="contacto">Contacto do cliente.</param>
        /// <param name="idade">Idade do cliente</param>
        /// <param name="sexo">Sexo do cliente</param>
        public Cliente(int id, string nome, int contacto, int idade, string sexo)
        {
            this.id = id;
            this.nome = nome;
            this.contacto = contacto;
            Idade = idade;
            Sexo = sexo;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Obtém ou define o id
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Obtém ou define o nome
        /// </summary>
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        /// <summary>
        /// Obtém ou define o contacto
        /// </summary>
        public int Contacto
        {
            get
            {
                return contacto;
            }
            set
            {
                contacto = value;
            }
        }


        #endregion

        /// <summary>
        /// Determina se dois objetos do tipo Cliente são iguais com base no contacto
        /// </summary>
        /// <param name="obj">Objeto a ser comparado</param>
        /// <returns>True se os contactos forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente c = (Cliente)obj;

                if (this.contacto == c.contacto)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna uma representação textual do objeto Cliente
        /// </summary>
        /// <returns>String contendo o Id e o nome do cliente</returns>
        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}";
        }

        // <summary>
        /// Compara dois objetos do tipo Cliente com base no Id
        /// </summary>
        /// <param name="c">Outro objeto do tipo Cliente a ser comparado</param>
        public int CompareTo(Cliente c)
        {
            return id.CompareTo(c.id);
        }
    }
}
