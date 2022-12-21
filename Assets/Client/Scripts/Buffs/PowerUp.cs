using UnityEngine;
using TMPro;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text descriptionText;
    private PlayerController playerController;
    private GameObject player;
    private Buff buff;

    public void Awake()
    {
        Shop shop = GetComponentInParent<Shop>();
        buff = shop.GetBuff();
        GetComponent<SpriteRenderer>().sprite = buff.GetBuffSprite();
        priceText.text = buff.GetBuffEffect().getPrice().ToString();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponentInParent(typeof(PlayerController)) as PlayerController;
            if(playerController != null)
            {
                this.playerController = (PlayerController)collision.GetComponentInParent(typeof(PlayerController));
                this.playerController.NextToTheBuff(this);
                player = collision.gameObject;
                descriptionText.text = buff.GetBuffDescription();
                descriptionText.fontSize = 6.5f;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.NotNextToTheBuff();
            playerController = null;
            player = null;
            descriptionText.text = "";
        }
    }

    public IEnumerator Apply()
    {
        Shop shop = GetComponentInParent(typeof(Shop)) as Shop;
        if(shop != null)
        {
            if (shop.GetCoins() >= buff.GetBuffEffect().getPrice())
            {
                shop.RemoveCoins(buff.GetBuffEffect().getPrice());
                buff.GetBuffEffect().Apply(player);
                Destroy(gameObject);
            }
            else 
            {
                Color priceColor = priceText.color;
                priceText.color = Color.red;
                yield return new WaitForSeconds(2);
                priceText.color = priceColor;
            }
        } 
    }
}
