using Devs2Blu.ProjetosAula.SistemaCadastro.Models.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Forms.Data
{
    public class PacienteRepository
    {
        public PessoaRepository PessoaRepository = new PessoaRepository();
        public EnderecoRepository EnderecoRepository = new EnderecoRepository();
        public Paciente Save(Paciente paciente, Endereco endereco = null)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {

                paciente.Pessoa.Id = PessoaRepository.Save(paciente.Pessoa, conn);

                if (paciente.Pessoa.Id != null &&
                    paciente.Pessoa.Id > 0)
                {
                    if (endereco != null)
                    {
                        endereco.Pessoa = paciente.Pessoa;
                        if (!EnderecoRepository.Save(endereco, conn))
                        {
                            MessageBox.Show("Ocorreu um erro ao tentar salvar o endereço da Pessoa", "Erro de Ao Salvar Endere~ço", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    paciente.Id = SavePaciente(paciente, conn);
                }

                conn.Close();

                return paciente;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private Int32 SavePaciente(Paciente paciente, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_PACIENTE, conn);
                cmd.Parameters.Add("@id_pessoa", MySqlDbType.Int32).Value = paciente.Pessoa.Id;
                cmd.Parameters.Add("@id_convenio", MySqlDbType.Int32).Value = paciente.Convenio.Id;
                int nrProntuario;
                Int32.TryParse($"{DateTime.Now.Millisecond}{DateTime.Now.Second}", out nrProntuario);
                cmd.Parameters.Add("@numero_prontuario", MySqlDbType.Int32).Value = nrProntuario;

                cmd.ExecuteNonQuery();
                return (Int32)cmd.LastInsertedId;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool Delete(int id)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_PACIENTE, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public MySqlDataReader GetPacientes()
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_PACIENTES, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public MySqlDataReader GetPacienteById(int idPaciente)
        {
            MySqlConnection conn = ConnectionMySQL.GetConnection();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_PACIENTE_BY_ID, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idPaciente;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #region SQLS
        private const String SQL_INSERT_PACIENTE = @"INSERT INTO paciente
(id_pessoa,
id_convenio,
numero_prontuario,
paciente_risco,
flstatus,
flobito)
VALUES
(@id_pessoa,
@id_convenio,
@numero_prontuario,
'NÃO',
'A',
0)";
        private const String SQL_SELECT_PACIENTES = @"SELECT * from paciente";
        private const String SQL_DELETE_PACIENTE = @"DELETE from paciente WHERE id_pessoa = @id";
        private const String SQL_SELECT_PACIENTE_BY_ID = @"select p.id,
	   pa.id as id_paciente,
       p.nome,
       p.cgccpf,
       p.tipopessoa,
       pa.numero_prontuario,
       pa.id_convenio,
       c.nome,
       e.CEP,
       e.rua,
       e.numero,
       e.bairro,
       e.cidade,
       e.uf
from pessoa p
join paciente pa 
	on pa.id_pessoa = p.id
join convenio c 
	on pa.id_convenio = c.id
join endereco e 
	on e.id_pessoa = p.id
WHERE p.id = @id";
        #endregion
    }
}
