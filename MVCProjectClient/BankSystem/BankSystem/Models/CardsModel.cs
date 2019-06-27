using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;


namespace BankSystem.Models
{

    #region Models

    public class CardsModel
    {
        [Required]
        [DisplayName("Card name")]
        public string Nazwa { get; set; }


        [Required]
        [DisplayName("Card number")]
        public ulong Nr_karta { get; set; }
    }


    public class DoladowanieModel
    {

        [Required]
        [DisplayName("From the account:")]
        public string SelectedCardName { get; set; }

        [Required]
        [DisplayName("Phone number:")]
        public ulong Numer { get; set; }

        [Required]
        [DisplayName("Amount:")]
        public float Kwota { get; set; }


    }

    public class PrzelewyModel
    {
        [Required]
        [DisplayName("From the account:")]
        public string SelectedCardName { get; set; }

        [Required]
        [DisplayName("To account:")]
        public ulong Nr_Card { get; set; }

        [Required]
        [DisplayName("Name of recipient:")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Region:")]
        public string Miejscowosc { get; set; }

        [Required]
        [DisplayName("Street:")]
        public string Ulica { get; set; }

        [Required]
        [DisplayName("Post code:")]
        public string Kod { get; set; }

        [Required]
        [DisplayName("Amount:")]
        public float Kwota { get; set; }

        [Required]
        [DisplayName("Title:")]
        public string Tytul { get; set; }

    }

    public class AddNewCardModel
    {
        [Required]
        [DisplayName("Card number")]
        public ulong Nr_card { get; set; }

        [Required]
        [DisplayName("Available")]
        public float Srodki { get; set; }

        [Required]
        [DisplayName("Balance")]
        public float Saldo { get; set; }

    }

    public class CardsResult
    {
        public int Id { get; set; }

        public long CardNumber { get; set; }

        public string Available { get; set; }

        public string Balance { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
    }

    public class CardsAdminResult
    {
        public long CardNumber { get; set; }

        public string Available { get; set; }

        public string Balance { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }

    public class HistoriaResult
    {
        public string Date { get; set; }

        public string Title { get; set; }

        public string Amount { get; set; }

        public string Balance { get; set; }
    }

    #endregion

//    #region Services

//    public interface ICardsService
//    {
//        DataTable GetCards(string id);
       
//        MembershipCreateStatus AddCard(string id,string nazwa, ulong nrKarta);

//        MembershipCreateStatus AddNewCard(ulong nrCard, float srodki, float saldo);

//        MembershipCreateStatus CreateTransaktion(string userId, string data, string tytul, float kwota, 
//            float saldo, string id);

//        MembershipCreateStatus CreateTransaktion(string userId, string data, string tytul, ulong nrCard,
//           string name,string miejscowosc, string ulica, string kod, float kwota, float saldo, string id);

//        float GetSaldoByCardName(string nazwa, string userId);

//        string GetIdByCardName(string nazwa, string userId);

//        DataTable GetTransaktionByUserId(string userId);

//        DataTable GetTransaktionByNrCard(ulong nrCard);

//        void GetExistingCard(ulong nrCard, float kwota);

//        DataTable GetCardsByAdmin();
        
//    }
//    public class CardsService : ICardsService
//    {

//        /// <summary>
//        /// metoda zwracająca wszystko z Products
//        /// </summary>
//        /// <returns>DataTable</returns>
//        public DataTable GetCards(string id)
//        {

//            DataTable table = new DataTable();
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand com = new SqlCommand("select * from Cards where ID_uzytkownik="+id, con);
//            com.Connection = con;
//            SqlDataAdapter adapt = new SqlDataAdapter(com);
//            con.Open();
//            adapt.Fill(table);
//            return table;
//        }
//        public DataTable GetCardsByAdmin()
//        {
//            DataTable table = new DataTable();
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand com = new SqlCommand("select * from Cards inner join Uzytkownik on Cards.ID_uzytkownik= Uzytkownik.ID_uzytkownik", con);
//            com.Connection = con;
//            SqlDataAdapter adapt = new SqlDataAdapter(com);
//            con.Open();
//            adapt.Fill(table);
//            return table;
//        }
//        public void GetExistingCard(ulong nrCard, float kwota)
//        {
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand com = new SqlCommand("select count(Saldo) from Cards where Nr_card="+nrCard, con);
           
           
//            com.Connection = con;
//            con.Open();
            
            
//                float saldo = float.Parse(com.ExecuteScalar().ToString());
//                saldo = saldo + kwota;
//                SqlCommand comm = new SqlCommand("update Cards set Saldo=" + saldo + ", Dostepne_srodki=" + saldo + " where Nr_card=" + nrCard, con);
//                comm.Connection = con;
//                comm.ExecuteScalar();
//                con.Close();
            

//        }
//        public DataTable GetTransaktionByUserId(string userId)
//        {
//            DataTable table = new DataTable();
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand com = new SqlCommand("select * from Transakcja where ID_uzytkownik="+userId, con);
//            com.Connection = con;
//            SqlDataAdapter adapt = new SqlDataAdapter(com);
//            con.Open();
//            adapt.Fill(table);
//            return table;
            
//        }
//        public DataTable GetTransaktionByNrCard(ulong nrCard)
//        {
//            DataTable table = new DataTable();
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand com = new SqlCommand("select * from Transakcja t inner join Uzytkownik u on t.ID_uzytkownik=u.ID_uzytkownik join Cards c on u.ID_uzytkownik=c.ID_uzytkownik  where Nr_card=" +nrCard, con);
//            com.Connection = con;
//            SqlDataAdapter adapt = new SqlDataAdapter(com);
//            con.Open();
//            adapt.Fill(table);
//            return table;
//        }
//        public MembershipCreateStatus AddCard(string id, string nazwa, ulong nrKarta)
//        {
//              if (String.IsNullOrEmpty(nazwa)) throw new ArgumentException("can't be empty", "nazwa");
//            if (nrKarta.Equals(null)) throw new ArgumentException("can't be empty", "nrKarta");
            

//            MembershipCreateStatus status;
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand comm = new SqlCommand("select count(*) from Cards where Nr_card=" + nrKarta );
//            comm.Connection = con;
//            con.Open();
//            if (Convert.ToInt32(comm.ExecuteScalar()) == 0)
//            {
//                status = MembershipCreateStatus.ProviderError;
//                con.Close();
//                return status;
//            }
            
//                SqlCommand com = new SqlCommand("update Cards set Nazwa='"+nazwa+"', ID_uzytkownik="+id+" where Nr_card="+nrKarta, con);
//                com.Connection = con;
//                com.ExecuteScalar();
            
//                con.Close();
//                status = MembershipCreateStatus.Success;
//                return status;
           
//        }
//       public  MembershipCreateStatus AddNewCard(ulong nrCard, float srodki, float saldo)
//        {
//            if (String.IsNullOrEmpty(nrCard.ToString())) throw new ArgumentException("can't be empty", "nrCard");
//            if (String.IsNullOrEmpty(srodki.ToString())) throw new ArgumentException("can't be empty", "srodki");
//            if (String.IsNullOrEmpty(saldo.ToString())) throw new ArgumentException("can't be empty", "saldo");


//            MembershipCreateStatus status;
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand comm = new SqlCommand("select count(*) from Cards where Nr_card=" + nrCard);
//            comm.Connection = con;
//            con.Open();
//            if (Convert.ToInt32(comm.ExecuteScalar())!=0)
//            {
//                status = MembershipCreateStatus.ProviderError;
//                con.Close();
//                return status;
//            }

//            SqlCommand com = new SqlCommand("insert into Cards values("+nrCard+","+srodki+","+saldo+",null,null) ", con);
//            com.Connection = con;
//            com.ExecuteScalar();

//            con.Close();
//            status = MembershipCreateStatus.Success;
//            return status;
//        }
//        public MembershipCreateStatus CreateTransaktion(string userId, string data, string tytul, float kwota, float saldo, string id)
//        {

//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand comm = new SqlCommand("insert into Transakcja values("+userId+",'"+data+"', '"+tytul+"',"+kwota+","+saldo+")",con);
           
//                saldo = saldo - kwota;
//                SqlCommand com = new SqlCommand("update Cards set Saldo=" + saldo + ", Dostepne_srodki=" + saldo + " where ID_card=" + id, con);
//                comm.Connection = con;
//                con.Open();
//                comm.ExecuteScalar();
//                com.Connection = con;
//                com.ExecuteScalar();
//                con.Close();
//                MembershipCreateStatus status;
//                status = MembershipCreateStatus.Success;
//            return status;

//        }
//        public MembershipCreateStatus CreateTransaktion(string userId, string data, string tytul, ulong nrCard,
//           string name, string miejscowosc, string ulica, string kod, float kwota, float saldo, string id)
//        {

//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand comm = new SqlCommand("insert into Transakcja values(" + userId + ",'" + data + "', '" + tytul+" "+nrCard.ToString()+" "+name+" "+miejscowosc+" "+ulica+" "+kod+ "'," + kwota + "," + saldo + ")", con);
            
//                saldo = saldo - kwota;
//                SqlCommand com = new SqlCommand("update Cards set Saldo=" + saldo + ", Dostepne_srodki=" + saldo + " where ID_card=" + id, con);
//                comm.Connection = con;
                
//                con.Open();
//                comm.ExecuteScalar();
//                com.Connection = con;
//                com.ExecuteScalar();
//                con.Close();
//                MembershipCreateStatus status;
//                status = MembershipCreateStatus.Success;
//                return status;
//        }
//        public float GetSaldoByCardName(string nazwa, string userId)
//        {
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand comm = new SqlCommand("select Saldo from Cards where Nazwa='" + nazwa + "'and ID_uzytkownik=" + userId, con);
//            comm.Connection = con;
//            con.Open();
            
//                float saldo = float.Parse(comm.ExecuteScalar().ToString());
//                con.Close();
           
//            return saldo;

//        }
//        public string GetIdByCardName(string nazwa, string userId)
//        {
//            SqlConnection con = new SqlConnection(@"Data Source=IE11WIN7\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
//            SqlCommand comm = new SqlCommand("select ID_card from Cards where Nazwa='"+nazwa+"' and ID_uzytkownik="+userId,con);
//            comm.Connection = con;
//            con.Open();
//            string id = comm.ExecuteScalar().ToString();
//            con.Close();
//            return id;

//        }
//        }
//#endregion
}