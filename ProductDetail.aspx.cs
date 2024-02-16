using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_end_s3_l05
{
    public partial class ProductDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recupera il codice articolo dalla query string
                string codiceArticolo = Request.QueryString["codice"];
                if (!string.IsNullOrEmpty(codiceArticolo))
                {
                    // Carica e visualizza i dettagli dell'articolo
                    Articolo articolo = GetArticoloFromDatabase(codiceArticolo);
                    if (articolo != null)
                    {
                        lblNome.Text = articolo.Nome;
                        lblDescrizione.Text = articolo.Descrizione;
                        lblPrezzo.Text = articolo.Prezzo.ToString("C");
                    }
                }
            }
        }

        protected void AggiungiAlCarrello_Click(object sender, EventArgs e)
        {
            // Recupera il codice articolo dalla query string
            string codiceArticolo = Request.QueryString["codice"];
            if (!string.IsNullOrEmpty(codiceArticolo))
            {
                // Recupera il carrello dalla Session o crea un nuovo carrello se non esiste
                List<Articolo> carrello = Session["Carrello"] as List<Articolo>;
                if (carrello == null)
                {
                    carrello = new List<Articolo>();
                }

                // Recupera l'articolo dal database usando il codice articolo
                Articolo articolo = GetArticoloFromDatabase(codiceArticolo);
                if (articolo != null)
                {
                    // Aggiunge l'articolo al carrello
                    carrello.Add(articolo);
                    // Aggiorna la Session con il nuovo carrello
                    Session["Carrello"] = carrello;
                }
            }
            // Reindirizza l'utente alla pagina del carrello
            Response.Redirect("ShoppingCart.aspx");
        }

        // Metodo per ottenere un articolo dall'archivio (può essere simulato con classi statiche)
        private Articolo GetArticoloFromDatabase(string codiceArticolo)
        {
            // Implementazione per ottenere l'articolo con il codice specificato (può essere sostituita con classi statiche)
            // Esempio:
            if (codiceArticolo == "001")
                return new Articolo("001", "Chitarra Elettrica", "Descrizione prodotto", 439.99m);
            else if (codiceArticolo == "002")
                return new Articolo("002", "Tromba", "Descrizione prodotto", 75.49m);
            else if (codiceArticolo == "003")
                return new Articolo("003", "Sassofono", "Descrizione prodotto", 200.99m);
            else if (codiceArticolo == "004")
                return new Articolo("004", "Tastiera", "Descrizione prodotto", 160.99m);
            else if (codiceArticolo == "005")
                return new Articolo("005", "Chitarra Acustica", "Descrizione prodotto", 100.99m);
            else if (codiceArticolo == "006")
                return new Articolo("006", "Basso", "Descrizione prodotto", 245.99m);
            else
                return null;
        }
    }
}