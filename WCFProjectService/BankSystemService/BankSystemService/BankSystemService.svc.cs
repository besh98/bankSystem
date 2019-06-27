using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

namespace BankSystemService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BankSystemService : IBankSystemService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region GetCards
        public List<CardsView> GetCards(string id)
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return context.CardsViews.Where(c => c.UserId == id).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 
        #endregion

        #region GetCardsWithoutUser
        public List<CardsView> GetCardsWithoutUser()
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return context.CardsViews.Where(c => c.UserId == null).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion

        #region GetCardsByAdmin
        public List<UserCardsView> GetCardsByAdmin()
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return context.UserCardsViews.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 
        #endregion

        #region GetExistingCard
        public void GetExistingCard(ulong nrCard, float kwota)
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    var card =
                        context.Cards.Where(c => c.CardNumber == (long)nrCard).FirstOrDefault();
                    var saldo = (float.Parse(card.Balance) + kwota).ToString();
                    card.Balance = saldo;
                    card.Available = saldo;
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        } 
        #endregion

        #region GetTransaktionsByUserId
        public List<TransactionsView> GetTransaktionsByUserId(string userId)
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return context.TransactionsViews.Where(c => c.UserId == userId).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 
        #endregion

        #region GetTransaktionsByNrCard
        public List<TransactionsUsersCardsView> GetTransaktionsByNrCard(ulong nrCard)
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return context.TransactionsUsersCardsViews.Where(c => c.CardNumber == (long)nrCard).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 
        #endregion

        #region AddCard
        public MembershipCreateStatus AddCard(string id, string nazwa, ulong nrKarta)
        {
            MembershipCreateStatus status;

            using (var context = new BankSystemEntities())
            {
                try
                {
                    var card = context.Cards.Where(c => c.CardNumber == (long) nrKarta).FirstOrDefault();
                    
                    if (card != null)
                    {
                        card.Name = nazwa;
                        card.UserId = id;
                        context.SaveChanges();
                        status = MembershipCreateStatus.Success;

                        return status;
                    }
                    else
                    {
                        status = MembershipCreateStatus.ProviderError;

                        return status;
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        } 
        #endregion

        #region AddNewCard
        public MembershipCreateStatus AddNewCard(ulong nrCard, float srodki, float saldo)
        {
            MembershipCreateStatus status;

            using (var context = new BankSystemEntities())
            {
                try
                {
                    if (context.Cards.Where(c => c.CardNumber == (long)nrCard).Any())
                    {
                        status = MembershipCreateStatus.ProviderError;

                        return status;
                    }
                    else
                    {
                        var card = new Card()
                        {
                            CardNumber = (long)nrCard,
                            Available = srodki.ToString(),
                            Balance = saldo.ToString()
                        };
                        context.Cards.Add(card);
                        context.SaveChanges();
                        status = MembershipCreateStatus.Success;

                        return status;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        } 
        #endregion

        #region CreateTransaktion
        public MembershipCreateStatus CreateTransaktion(string userId, DateTime? data, string tytul, float kwota, float saldo, int id)
        {
            MembershipCreateStatus status;
            using (var context = new BankSystemEntities())
            {
                try
                {
                    var transaction = new Transaction()
                    {
                        UserId = userId,
                        Date = data,
                        Title = tytul,
                        Amount = kwota.ToString(),
                        Balance = saldo.ToString()
                    };
                    context.Transactions.Add(transaction);

                    var card = context.Cards.Where(c => c.Id == id).FirstOrDefault();

                    if (card != null)
                    {
                        saldo -= kwota;
                        card.Balance = saldo.ToString();
                        card.Available = saldo.ToString();
                        context.SaveChanges();
                        status = MembershipCreateStatus.Success;

                        return status;
                    }
                    else
                    {
                        status = MembershipCreateStatus.ProviderError;

                        return status;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        } 
        #endregion

        #region CreateTransaktion
        public MembershipCreateStatus CreateFullTransaktion(string userId, DateTime? data, string tytul, ulong nrCard,
           string name, string miejscowosc, string ulica, string kod, float kwota, float saldo, int id)
        {
            MembershipCreateStatus status;
            using (var context = new BankSystemEntities())
            {
                try
                {
                    var transaction = new Transaction()
                    {
                        UserId = userId,
                        Date = data,
                        Title = " " + tytul + " " + nrCard.ToString() + " " + name + " " + miejscowosc + " " + ulica + " " + kod + " ",
                        Amount = kwota.ToString(),
                        Balance = saldo.ToString(),

                    };
                    context.Transactions.Add(transaction);

                    var card = context.Cards.Where(c => c.Id == id).FirstOrDefault();

                    if (card != null)
                    {
                        saldo -= kwota;
                        card.Balance = saldo.ToString();
                        card.Available = saldo.ToString();
                        context.SaveChanges();
                        status = MembershipCreateStatus.Success;

                        return status;
                    }
                    else
                    {
                        status = MembershipCreateStatus.ProviderError;

                        return status;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 
        #endregion

        #region GetSaldoByCardName
        public float GetSaldoByCardName(string nazwa, string userId)
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return
                        float.Parse(context.UserCardsViews.Where(c => c.UserId == userId && c.CardName == nazwa)
                            .Select(c => c.Balance)
                            .FirstOrDefault());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        } 
        #endregion

        #region GetIdByCardName
        public int GetIdByCardName(string nazwa, string userId)
        {
            using (var context = new BankSystemEntities())
            {
                try
                {
                    return
                        context.UserCardsViews.Where(c => c.UserId == userId && c.CardName == nazwa)
                            .Select(c => c.CardId)
                            .FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        } 
        #endregion
    }

    //public partial class CardsView
    //{
    //    [DataMember(Name = "Id")]
    //    public int id
    //    {
    //        get { return Id; }
    //        set { Id = value; }
    //    }

    //    [DataMember(Name = "CardNumber")]
    //    public long cardNumber
    //    {
    //        get { return CardNumber; }
    //        set { CardNumber = value; }
    //    }

    //    [DataMember(Name = "Available")]
    //    public string available
    //    {
    //        get { return Available; }
    //        set { Available = value; }
    //    }

    //    [DataMember(Name = "Balance")]
    //    public string balance
    //    {
    //        get { return Balance; }
    //        set { Balance = value; }
    //    }

    //    [DataMember(Name = "Name")]
    //    public string name
    //    {
    //        get { return Name; }
    //        set { Name = value; }
    //    }

    //    [DataMember(Name = "UserId")]
    //    public string userId
    //    {
    //        get { return UserId; }
    //        set { UserId = value; }
    //    }
    //}
}
