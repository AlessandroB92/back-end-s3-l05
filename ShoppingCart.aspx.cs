using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_end_s3_l05
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Popolare GridView con il carrello
                List<Articolo> carrello = Session["Carrello"] as List<Articolo>;
                if (carrello != null && carrello.Count > 0)
                {
                    GridViewCart.DataSource = carrello;
                    GridViewCart.DataBind();
                    CalcolaTotale();
                }
                else
                {
                    // Carrello vuoto
                    lblTotale.Text = "Il carrello è vuoto.";
                }
            }
        }

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Rimuovi")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Articolo> carrello = Session["Carrello"] as List<Articolo>;
                carrello.RemoveAt(index);
                Session["Carrello"] = carrello;
                GridViewCart.DataSource = carrello;
                GridViewCart.DataBind();
                CalcolaTotale();
            }
        }

        protected void SvuotaCarrello_Click(object sender, EventArgs e)
        {
            Session.Remove("Carrello");
            Response.Redirect("ShoppingCart.aspx");
        }
        protected void Rimuovi_Click(object sender, EventArgs e)
        {
            // Ottieni l'indice dell'articolo da rimuovere dal comando
            int index = Convert.ToInt32(((Button)sender).CommandArgument);

            // Ottieni il carrello dalla sessione
            List<Articolo> carrello = Session["Carrello"] as List<Articolo>;

            // Rimuovi l'articolo dal carrello
            if (carrello != null && index >= 0 && index < carrello.Count)
            {
                carrello.RemoveAt(index);

                // Aggiorna il carrello nella sessione
                Session["Carrello"] = carrello;

                // Ricarica la GridView e calcola il totale
                GridViewCart.DataSource = carrello;
                GridViewCart.DataBind();
                CalcolaTotale();
            }
        }

        private void CalcolaTotale()
        {
            decimal totale = 0;
            List<Articolo> carrello = Session["Carrello"] as List<Articolo>;
            foreach (Articolo articolo in carrello)
            {
                totale += articolo.Prezzo;
            }
            lblTotale.Text = "Totale: " + totale.ToString("C");
        }
    }
}