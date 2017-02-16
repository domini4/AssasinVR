using UnityEngine;
using System.Collections;
public class AKMShoot : MonoBehaviour {
		
	private SteamVR_TrackedController device;
	public GameObject prefabBullet;
	public float shootfoce;
	public Transform shootPosition;
    public AudioClip shootSound;
    public AudioClip clickSound;
	GameObject instanceBullet;

	public static class Globals 
	{
		public static bool GunFired = false;
	}
	void Start() {
		device = GetComponent<SteamVR_TrackedController>();
		if (device== null)
		{
			device = gameObject.AddComponent<SteamVR_TrackedController>();
		}
		device.TriggerClicked += Trigger;
	}
	void Trigger(object sender, ClickedEventArgs e)
	{
		if (GameManager.Instance.ammuNum > 0) {
			instanceBullet = Instantiate (prefabBullet, shootPosition.position + shootPosition.forward, shootPosition.transform.rotation) as GameObject;
			GetComponent<AudioSource> ().PlayOneShot (shootSound);
			instanceBullet.GetComponent<Rigidbody> ().AddForce (shootPosition.forward * shootfoce);
			GameManager.Instance.AmmunationDeduct (1);
			Globals.GunFired = true;
		} else {
			GetComponent<AudioSource> ().PlayOneShot (clickSound);
		}

	}

}