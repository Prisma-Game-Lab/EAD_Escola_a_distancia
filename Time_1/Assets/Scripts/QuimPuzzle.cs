using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuimPuzzle : MonoBehaviour
{
        public Inventory iniciais;
        public Inventory finais;
        public Inventory mesa;
        public Inventory playerInv;
        public GameObject panel;
        [SerializeField] private List<Item> mix1;
        [SerializeField] private List<Item> mix2;
        [SerializeField] private List<Item> mix3;
        [SerializeField] private List<Item> mixItems;
        
        void Update()
        {
            if (mesa.changed && mesa.itemList[0] != null && mesa.itemList[1] != null)
            {
                int ind = CheckMix();
                if (ind == -1)
                {
                    return;
                }

                if (ind == 2)
                {
                    playerInv.AddItem(mixItems[2]);
                    panel.SetActive(false);
                    //MARRETEI PQ TA SEM TEMPO
                    mesa.RemoveItem(mesa.itemList[0]);
                    mesa.RemoveItem(mesa.itemList[1]);
                }
                mesa.RemoveItem(mesa.itemList[0]);
                mesa.RemoveItem(mesa.itemList[1]);
                finais.AddItem(mixItems[ind]);
            }
        }

        int CheckMix()
        {
            if ((mesa.itemList[0] == mix1[0] && mesa.itemList[1] == mix1[1]) || (mesa.itemList[0] == mix1[1] && mesa.itemList[1] == mix1[0]))
            {
                return 0;
            }
            if ((mesa.itemList[0] == mix2[0] && mesa.itemList[1] == mix2[1]) || (mesa.itemList[0] == mix2[1] && mesa.itemList[1] == mix2[0]))
            {
                return 1;
            }
            if ((mesa.itemList[0] == mix3[0] && mesa.itemList[1] == mix3[1]) || (mesa.itemList[0] == mix3[1] && mesa.itemList[1] == mix3[0]))
            {
                return 2;
            }
            return -1;

        }
}
