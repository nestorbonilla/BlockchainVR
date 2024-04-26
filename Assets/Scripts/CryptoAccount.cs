using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoAccount : MonoBehaviour
{
    public string mnemonic;
    public string password;
    
    // Método para configurar el objeto con el mnemonic y password
    public void SetupAccount(string mnemonic, string password)
    {
        this.mnemonic = mnemonic;
        this.password = password;
    }
    
    public string GetAccountInfo()
    {
        // Crear una nueva wallet
        var wallet = new Nethereum.HdWallet.Wallet(mnemonic, password);
        var account = wallet.GetAccount(0);
        var accountInfo = "Hey Anon! Ready to dive into web3?\n";
        accountInfo += "Here's your burner wallet. Remember, it's for fun, not to store real value! \n\n";
        accountInfo += "************************************************\n";
        accountInfo += "address: \n" + account.Address + "\n";
        accountInfo += "private key: \n" + account.PrivateKey + "\n";
        accountInfo += "mnemonic: \n" + this.mnemonic + "\n";

        return accountInfo;
        Debug.Log("Address at Index 0 is: " + account.Address + " with private key:" + account.PrivateKey);
    }
}
