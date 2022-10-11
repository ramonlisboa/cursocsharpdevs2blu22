using Devs2Blu.ProjetosAula.SistemaCadastro.Forms.Data;
using Devs2Blu.ProjetosAula.SistemaCadastro.Models.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.SistemaCadastro.Forms
{
    public partial class Form1 : Form
    {
        public MySqlConnection Conn { get; set; }
        public ConvenioRepository ConvenioRepository = new ConvenioRepository();
        public PacienteRepository PacienteRepository = new PacienteRepository();
        public PessoaRepository PessoaRepository = new PessoaRepository();
        public EnderecoRepository EnderecoRepository = new EnderecoRepository();
        public Paciente PacienteForm = new Paciente();
        public Pessoa PessoaForm = new Pessoa();
        public Endereco EnderecoForm = new Endereco();

        public Form1()
        {
            InitializeComponent();
        }

        #region Methods
        private void PopulaComboConvenio()
        {
            var listConvenios = ConvenioRepository.FetchAll();
            cboConvenio.DataSource = new BindingSource(listConvenios, null);
            cboConvenio.DisplayMember = "nome";
            cboConvenio.ValueMember = "id";
        }

        private void PopulaDataGridPessoa()
        {
            var listPessoas = PessoaRepository.GetPessoas();
            gridPacientes.DataSource = new BindingSource(listPessoas, null);
        }
        private bool ValidaFormCadastro()
        {
            if (txtNome.Text.Equals(""))
                return false;
            if (txtCGCCPF.Text.Equals(""))
                return false;
            /*if (cboConvenio.SelectedIndex == -1)
                return false;
            if (mskCEP.Text.Equals(""))
                return false;
            if (cboUF.SelectedIndex == -1)
                return false;
            if (txtCidade.Text.Equals(""))
                return false;
            if (txtRua.Text.Equals(""))
                return false;
            if (txtNumero.Text.Equals(""))
                return false;
            if (txtBairro.Text.Equals(""))
                return false;*/

            return true;
        }
       
        private void AtualizaCamposForm()
        {
            PacienteForm.Pessoa.Nome = txtNome.Text;
            PacienteForm.Pessoa.CGCCPF = txtCGCCPF.Text.Replace(',', '.');
            PacienteForm.Convenio.Id = (int)cboConvenio.SelectedValue;

            EnderecoForm.CEP = mskCEP.Text;
            EnderecoForm.Rua = txtRua.Text;
            EnderecoForm.Numero = Int32.Parse(txtNumero.Text);
            EnderecoForm.Bairro = txtBairro.Text;

        }
        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            #region TesteConexao
            /*Conn = ConnectionMySQL.GetConnection();

            if (Conn.State == ConnectionState.Open)
            {
                MessageBox.Show("Conexão efetuada com sucesso!", "Conexão ao MySQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Conn.Close();
            }*/
            #endregion
            PopulaComboConvenio();
        }

        private void rdFisica_CheckedChanged(object sender, EventArgs e)
        {
            lblCGCCPF.Text = "CPF";
            lblCGCCPF.Visible = true;
        }

        private void rdJuridica_CheckedChanged(object sender, EventArgs e)
        {
            lblCGCCPF.Text = "CNPJ";
            lblCGCCPF.Visible = true;
        }
        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaFormCadastro())
            {
                AtualizaCamposForm();

                
                var pacienteResult = PacienteRepository.Save(PacienteForm,EnderecoForm);
                if (pacienteResult.Pessoa.Id > 0)
                {
                    MessageBox.Show($"Pessoa {pacienteResult.Pessoa.Id} - {pacienteResult.Pessoa.Nome} salva com sucesso!", "Adicionar Pessoa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PopulaDataGridPessoa();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var index = gridPacientes.CurrentCell.RowIndex;
            int idPessoa = (int)gridPacientes.Rows[index].Cells["id"].Value;
            if (PacienteRepository.Delete(idPessoa))
            {
                if (EnderecoRepository.Delete(idPessoa))
                {
                    if (PessoaRepository.Delete(idPessoa))
                    {
                        MessageBox.Show($"Pessoa {idPessoa} excluída com sucesso!", "Excluir Pessoa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            PopulaDataGridPessoa();
        }

        #endregion

        private void gridPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idPessoa = (int)gridPacientes.Rows[e.RowIndex].Cells["id"].Value;
            MySqlDataReader rdrP = PacienteRepository.GetPacienteById(idPessoa);

            while (rdrP.Read())
            {
                txtNome.Text = rdrP.GetString("nome");
                txtCGCCPF.Text = rdrP.GetString("cgccpf");
                mskCEP.Text = rdrP.GetString("CEP");
                txtRua.Text = rdrP.GetString("rua");
                txtNumero.Text = rdrP.GetString("numero");
                txtBairro.Text = rdrP.GetString("bairro");
                txtCidade.Text = rdrP.GetString("cidade");
            }
        }
    }
}
