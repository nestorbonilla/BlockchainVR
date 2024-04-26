using System.Collections;
using System.Collections.Generic;
using NBitcoin;
using Nethereum.HdWallet;
using UnityEngine;

public class CryptoManager : MonoBehaviour
{
    
    [SerializeField]
    private CryptoManager _cryptoManager;
    [SerializeField] public GameObject diskPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // CreateWallet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateWallet()
    {
        // Create a new wallet
        var mnemonic = new NBitcoin.Mnemonic(Wordlist.English, WordCount.Twelve);
        Debug.Log("The 12 seed words are: " + mnemonic.ToString());

        var password = "password";
        // var wallet = new Wallet(mnemonic.ToString(), password);
        // var account = wallet.GetAccount(0);
        // Debug.Log("Address at Index 0 is: " + account.Address + " with private key:" + account.PrivateKey);
        
        if (diskPrefab != null)
        {
            // Instantiate the prefab in the scene
            GameObject newObject = Instantiate(diskPrefab, new Vector3(-0.7f, 0.78f, 0f), Quaternion.identity);
            CryptoAccount walletObject = newObject.GetComponent<CryptoAccount>();
            if (walletObject != null)
            {
                // Configurar el objeto con los datos generados de la wallet
                walletObject.SetupAccount(mnemonic.ToString(), password);
            }
            else
            {
                Debug.LogWarning("El objeto no tiene el componente WalletObject adjunto.");
            }
            // Configure the object with the wallet-generated data
            // For example, you could set the object's name as the account address
            // newObject.name = "Wallet_" + account.Address;

            // You can also perform other configurations as needed
        }
    }
}
