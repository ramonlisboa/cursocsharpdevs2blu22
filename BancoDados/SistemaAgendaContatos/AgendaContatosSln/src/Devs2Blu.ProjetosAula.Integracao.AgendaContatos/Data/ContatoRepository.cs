using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data
{
    public class ContatoRepository: BaseRepository
    {
        public ContatoRepository() : base("contatos")
        {
                
        }

        public Contato FindById(int id)
        {
            Contato contato = new Contato();
            var r = base.FindById(id);
            while (r.Read())
            {
                contato = new Contato(r.GetInt32("id"), r.GetString("nome"), r.GetString("telefone"), r.GetString("celular"), r.GetString("email"), r.GetString("rua"), r.GetInt32("numero"), r.GetString("bairro"), r.GetString("cidade"), r.GetString("uf"), GetStatus(r.GetString("status")));
            }

            return contato;
        }

        public List<Contato> GetContatosCbo()
        {
            List <Contato> listContato = new List<Contato>();
            Contato itemZero = new Contato(0, "Selecione...");
            listContato.Add(itemZero);

            var rdr = base.Get(SQL_CONTATOS_CBO);
            while (rdr.Read())
            {
                Contato contato = new Contato(rdr.GetInt32("id"), rdr.GetString("nome"));
                listContato.Add(contato);
            }

            return listContato;
        }


        #region SQLs
        const string SQL_CONTATOS_CBO = "SELECT id, concat(nome,' (',  telefone, ')') as nome from contatos;";

        #endregion
    }
}
