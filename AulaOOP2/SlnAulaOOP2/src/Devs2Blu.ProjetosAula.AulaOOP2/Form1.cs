using Devs2Blu.ProjetosAula.OOP2Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.AulaOOP2
{
    public partial class Form1 : Form
    {
        public Contato Contato { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Form1_Load(object sender, EventArgs e)
        {
            Contato = new Contato();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidaForm())
            {
                MessageBox.Show(this, "Preencha todos os campo!", "Erro - Formulário de contato",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BindClass();
            
            String textoMsg = $"{txtNome.Text}, texto enviado com sucesso!";
            MessageBox.Show(this, textoMsg,"Formulário de contato");
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }
        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            //89069150 (Length - 8)
            if (txtCEP.Text.Length == 8)
            {
                txtRua.Text = "7 de Setembro";
                txtBairro.Text = "Centro";
                txtCidade.Text = "Blumenau";
                txtEstado.Text = "SC";
            } else
            {
                txtRua.Clear();
                txtBairro.Clear();
                txtCidade.Clear();
                txtEstado.Clear();
            }
        }

        #endregion

        #region Metodos

        public void BindClass()
        {
            Contato.Nome = txtNome.Text;
            Contato.TelCel = txtTel.Text;
            Contato.Email = txtEmail.Text;
            Contato.CEP = txtCEP.Text;
            Contato.Rua = txtRua.Text;
        }
        public void LimparForm()
        {
            txtNome.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtCEP.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtTexto.Clear();
        }

        public bool ValidaForm()
        {
            if (txtNome.Text.Equals("")) return false;
            if (txtTel.Text.Equals("")) return false;            
            if (txtEmail.Text.Equals("")) return false;            
            if (txtCEP.Text.Equals("")) return false;            
            if (txtRua.Text.Equals("")) return false;            
            if (txtNumero.Text.Equals("")) return false;            
            if (txtBairro.Text.Equals("")) return false;            
            if (txtCidade.Text.Equals("")) return false;            
            if (txtEstado.Text.Equals("")) return false;            
            if (txtTexto.Text.Equals("")) return false;            
            return true;
        }
        #endregion

    }
}
