using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Models;
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

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos
{
    public partial class Form1 : Form
    {
        public EstadoRepository EstadoRepository { get; set; }
        public ContatoRepository ContatoRepository { get; set; }
        public Contato Contato { get; set; }
        public Form1()
        {
            InitializeComponent();
        }


        #region Methods

        private void PopulaComboEstados()
        {
            MySqlDataReader rdrEstados = EstadoRepository.GetAll();

            cboEstados.DataSource = new BindingSource(rdrEstados, null);
            cboEstados.DisplayMember = "descricao";
            cboEstados.ValueMember = "uf";
        }

        private void PopulaGridContatos()
        {
            MySqlDataReader rdrContatos = ContatoRepository.GetAll();
            gridContatos.DataSource = new BindingSource(rdrContatos, null);
        }

        private bool ValidaForm()
        {
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Favor informar um Nome!", "Validação de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            if (cboEstados.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Favor informar um Estado!", "Validação de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboEstados.Focus();
                return false;
            }
            return true;
        }

        private void SalvaContato()
        {
            string columns, values;
            var status = rdAtivo.Checked ? StatusEnum.A : StatusEnum.I;

            columns = "nome, telefone, celular, email, rua, numero, bairro, cidade, uf, status";
            values = $"'{Contato.Nome}','{Contato.Telefone}','{Contato.Celular}','{Contato.Email}','{Contato.Rua}',{Contato.Numero},'{Contato.Bairro}','{Contato.Cidade}','{Contato.UF}','{Contato.Status}'";

            try
            {
                int idInsert = ContatoRepository.Insert(columns, values);
                if (idInsert > 0)
                {
                    MessageBox.Show($"Contato {idInsert} - {txtNome.Text} salvo com sucesso!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AtualizaContato()
        {
            string columns;
            var status = rdAtivo.Checked ? StatusEnum.A : StatusEnum.I;

            columns = $@"nome = '{Contato.Nome}', 
telefone = '{Contato.Telefone}', 
celular ='{Contato.Celular}', 
email = '{Contato.Email}', 
rua = '{Contato.Rua}', 
numero = {Contato.Numero}, 
bairro = '{Contato.Bairro}', 
cidade = '{Contato.Cidade}', 
uf = '{Contato.UF}', 
status = '{Contato.Status}'";

            try
            {
                int idUpdate = ContatoRepository.Update(columns, Contato.Id);
                if (idUpdate > 0)
                {
                    MessageBox.Show($"Contato {Contato.Id} - {Contato.Nome} atualizado com sucesso!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FillClassContato()
        {
            Contato.Nome = txtNome.Text;
            Contato.Rua = txtRua.Text;
            Contato.Email = txtEmail.Text;
            Contato.Telefone = mskTel.Text;
            Contato.Celular = mskCel.Text;
            Contato.Numero = Int32.Parse(txtNumero.Text);
            Contato.Bairro = txtBairro.Text;
            Contato.Cidade = txtCidade.Text;
            Contato.UF = cboEstados.SelectedValue.ToString();
            Contato.Status = (rdAtivo.Checked) ? StatusEnum.A : StatusEnum.I;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtRua.Text = "";
            txtEmail.Text = "";
            mskTel.Text = "";
            mskCel.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cboEstados.SelectedIndex = -1;
            rdAtivo.Checked = true;
        }

        private void PopulaCamposForm()
        {
            txtNome.Text = Contato.Nome;
            txtRua.Text = Contato.Rua;
            txtEmail.Text = Contato.Email;
            mskTel.Text = Contato.Telefone;
            mskCel.Text = Contato.Celular;
            txtNumero.Text = Contato.Numero.ToString();
            txtBairro.Text = Contato.Bairro;
            txtCidade.Text = Contato.Cidade;
            cboEstados.SelectedValue = Contato.UF;
            rdAtivo.Checked = Contato.Status.Equals(StatusEnum.A)? true : false;
            rdInativo.Checked = Contato.Status.Equals(StatusEnum.I)? true : false;
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            EstadoRepository = new EstadoRepository();
            ContatoRepository = new ContatoRepository();
            Contato = new Contato();
            PopulaComboEstados();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            PopulaGridContatos();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                FillClassContato();
                if (Contato.Id > 0)
                {
                    AtualizaContato();
                } else
                {
                    SalvaContato();
                }
                Contato = new Contato();
                LimparCampos();
            }
        }
        private void gridContatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idContato = (int)gridContatos.Rows[e.RowIndex].Cells["id"].Value;
            Contato = ContatoRepository.FindById(idContato);
            PopulaCamposForm();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show($"Deseja Excluir o Contato {Contato.Id} - {Contato.Nome}?", "Excluir Contato", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (ContatoRepository.DeleteById(Contato.Id))
                {
                    MessageBox.Show($"Contato {Contato.Id} - {Contato.Nome} excluído com sucesso!");
                }
            }
            
        }

        private void gridContatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Contato = new Contato();
            Contato.Id = (int)gridContatos.Rows[e.RowIndex].Cells["id"].Value;
            Contato.Nome = (string)gridContatos.Rows[e.RowIndex].Cells["nome"].Value;
        }

        private void compromissosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompromissosForm comForm = new CompromissosForm();
            comForm.Show();
        }
    }
}
