using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

namespace BankSystemService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBankSystemService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<CardsView> GetCards(string id);

        [OperationContract]
        List<CardsView> GetCardsWithoutUser();

        [OperationContract]
        MembershipCreateStatus AddCard(string id, string nazwa, ulong nrKarta);

        [OperationContract]
        MembershipCreateStatus AddNewCard(ulong nrCard, float srodki, float saldo);

        [OperationContract]
        MembershipCreateStatus CreateTransaktion(string userId, DateTime? data, string tytul, float kwota,
            float saldo, int id);

        [OperationContract]
        MembershipCreateStatus CreateFullTransaktion(string userId, DateTime? data, string tytul, ulong nrCard,
           string name, string miejscowosc, string ulica, string kod, float kwota, float saldo, int id);

        [OperationContract]
        float GetSaldoByCardName(string nazwa, string userId);

        [OperationContract]
        int GetIdByCardName(string nazwa, string userId);

        [OperationContract]
        List<TransactionsView> GetTransaktionsByUserId(string userId);

        [OperationContract]
        List<TransactionsUsersCardsView> GetTransaktionsByNrCard(ulong nrCard);

        [OperationContract]
        void GetExistingCard(ulong nrCard, float kwota);

        [OperationContract]
        List<UserCardsView> GetCardsByAdmin();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
