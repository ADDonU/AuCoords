using UnityEngine;
using UnityEngine.UI;
namespace MoCore
{
    // Yelling Lion Studio © 2017
    public partial class UICoords : MonoBehaviour
	{
        // There are fields here we don't currently use yet so we will make this section pragmatic
        // to avoid warnings.
#pragma warning disable
        public GameObject coordsPanel;
		public Text coordText;
		public Button openButton;
#pragma warning restore
        void Start()
	{
		openButton.onClick.SetListener(() => {
			var player = Utils.ClientLocalPlayer();
			if (!player) return;
			if (player.isOn == true)
			{
				player.isOn = false;
                coordsPanel.SetActive(false);
                //coordText.text = ("");
            }
			else
			{
				player.isOn = true;
			}
		});
	}
		void Update()
		{
			var player = Utils.ClientLocalPlayer();
			coordsPanel.SetActive(player != null);
			if (!player) return;
		if (player.isOn == true)
		{
				#pragma warning disable
				Vector3 Movement = player.whereIs;
				#pragma warning restore
				player.whereIs.x = player.transform.position.x;
				player.whereIs.y = player.transform.position.y;
				player.whereIs.z = player.transform.position.z;
				string whereIsX = player.whereIs.x.ToString("F0");
				string whereIsY = player.whereIs.y.ToString("F0");
				string whereIsZ = player.whereIs.z.ToString("F0");
				coordText.text = whereIsX + " x " + whereIsY + " y " + whereIsZ + " z ";
				Utils.InvokeMany(typeof(UICoords), this, "Update_");
			}
		else if (player.isOn == false)
			{
				coordsPanel.SetActive(false);
                //coordText.text = ("");
            }
		}
	}
}
public partial class Player
{
    [HideInInspector] public Vector3 whereIs;
    [HideInInspector] public bool swatch = false;
    [HideInInspector] public bool isOn = true;
}