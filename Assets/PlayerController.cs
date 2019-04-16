using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using static Helpers;

public class PlayerController : MonoBehaviour
{

    public int Player2HP;
    public int Player1HP;
    AbstractSkill basicAttack, trippleAttack, healSkill;
    private bool isCastingSkill = false;
    public GameObject player1Model;
    public GameObject player2Model;
    public GameObject mainCamera;

    public Text Player1HPtext;
    public Text Player2HPtext;

    public RectTransform Player1HPbar;
    public RectTransform Player2HPbar;

    public GameObject gameOverPanel;


    public Text NoteText;

    public GameObject player1Skills;
    public GameObject player2Skills;

    string cameraPosition = "player1";

    string playerTurn = "player1";

    Dictionary<string, Vector3> cameraPositions = new Dictionary<string, Vector3> {
        ["player1"] = new Vector3(-42.92F, -1.3F, 10.05F),
        ["player1front"] = new Vector3(-47.4F, -3.2F, 24F),
        ["player2"] = new Vector3(-39.82F, -1.24F, 73.71F),
        ["player2front"] = new Vector3(-46.2F, -4.4F, 58.4F),
        ["player1dice"] = new Vector3(-81.12F, 7.06F, 53.65F)
    };

    Dictionary<string, Vector3> cameraRotations = new Dictionary<string, Vector3>
    {
        ["player1"] = new Vector3(15.269F, -28.558F, -0.284F),
        ["player1front"] = new Vector3(2.383F, 213.731F, -0.745F),
        ["player2"] = new Vector3(19.254F, 207.405F, -0.933F),
        ["player2front"] = new Vector3(-2.946F, 345.459F, 2.276F),
        ["player1dice"] = new Vector3(32.346F, 108.635F, -1.695F)
    };



    // Start is called before the first frame update
    void Start()
    {
        basicAttack = gameObject.AddComponent<BasicAttack>();
        trippleAttack = gameObject.AddComponent<TrippleAttack>();
        healSkill = gameObject.AddComponent<HealSkill>();
        //ba.ActivateSkill(addEnemyDamage);
    }

    // Update is called once per frame
    void Update()
    {
        Player1HPtext.text = Player1HP.ToString();
        Player2HPtext.text = Player2HP.ToString();

        Player1HPbar.sizeDelta = Vector2.Lerp(Player1HPbar.sizeDelta, new Vector2(15 * Player1HP, Player1HPbar.sizeDelta.y), Time.deltaTime * 10);
        Player2HPbar.sizeDelta = Vector2.Lerp(Player2HPbar.sizeDelta, new Vector2(15 * Player2HP, Player2HPbar.sizeDelta.y), Time.deltaTime * 10);

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPositions[cameraPosition], Time.deltaTime * 5);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, Quaternion.Euler(cameraRotations[cameraPosition]), Time.deltaTime * 5);
    }

    public void CastSkill(string type)
    {
        if (isCastingSkill)
            return;

        cameraPosition = "player1dice";

        if(playerTurn == "player1")
            player1Model.GetComponent<Animator>().Play("elfmage_attack1");
        else if(playerTurn == "player2")
            player2Model.GetComponent<Animator>().Play("elfmage_attack1");


        isCastingSkill = true;
        switch (type)
        {
            case "BasicAttack":
                basicAttack.ActivateSkill(NoteText, CastCallback);
                break;
            case "TrippleAttack":
                trippleAttack.ActivateSkill(NoteText, CastCallback);
                break;
            case "Heal":
                healSkill.ActivateSkill(NoteText, CastCallback);
                break;
        }
    }

    public void CastCallback(SkillType skillType, int value)
    {
        switch(skillType)
        {
            case SkillType.EnemyDamage:
                addEnemyDamage(value);
                break;
            case SkillType.PlayerHeal:
                addPlayerHeal(value);
                break;
        }
    }

    public void addEnemyDamage(int damage)
    {
        if(playerTurn == "player1")
            StartCoroutine(Player1Attack(damage));
        else if(playerTurn == "player2")
            StartCoroutine(Player2Attack(damage));
    }

    public void addPlayerHeal(int value)
    {
        if (playerTurn == "player1")
            StartCoroutine(Player1Heal(value));
        else if (playerTurn == "player2")
            StartCoroutine(Player2Heal(value));
    }

    IEnumerator Player1Attack(int damage)
    {
        yield return new WaitForSecondsRealtime(2);
        cameraPosition = "player1";
        yield return new WaitForSecondsRealtime(1);
        player1Model.GetComponent<Animator>().Play("elfmage_attack3");
        player1Skills.transform.Find("ErekiBall2").GetComponent<ParticleSystem>().Play();
        player1Skills.transform.Find("ErekiBall2").GetComponent<Animation>().Play();
        yield return new WaitForSecondsRealtime(1);
        cameraPosition = "player2front";
        yield return new WaitForSecondsRealtime(0.5F);
        player2Model.GetComponent<Animator>().Play("elfmage_damage");
        player1Skills.transform.Find("ErekiBall2").GetComponent<ParticleSystem>().Stop();
        Player2HP -= damage;
        if (Player2HP <= 0)
        {
            player2Model.GetComponent<Animator>().Play("elfmage_death");
            gameOverPanel.transform.Find("Text").GetComponent<Text>().text = "Player 1 wins";
            gameOverPanel.SetActive(true);
        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            cameraPosition = "player2";
            playerTurn = "player2";
            NoteText.text = "Choose skill";
            isCastingSkill = false;
        }
    }

    IEnumerator Player1Heal(int value)
    {
        yield return new WaitForSecondsRealtime(2);
        cameraPosition = "player1front";
        player1Skills.transform.Find("GreenCore").GetComponent<ParticleSystem>().Play();
        yield return new WaitForSecondsRealtime(1);
        player1Model.GetComponent<Animator>().Play("elfmage_attack1");
       
        Player1HP += value;

        yield return new WaitForSecondsRealtime(3);
        player1Skills.transform.Find("GreenCore").GetComponent<ParticleSystem>().Stop();
        cameraPosition = "player2";
        playerTurn = "player2";
        NoteText.text = "Choose skill";
        isCastingSkill = false;
    }

    IEnumerator Player2Attack(int damage)
    {
        yield return new WaitForSecondsRealtime(2);
        cameraPosition = "player2";
        yield return new WaitForSecondsRealtime(1);
        player2Model.GetComponent<Animator>().Play("elfmage_attack3");
        player2Skills.transform.Find("ErekiBall2").GetComponent<ParticleSystem>().Play();
        player2Skills.transform.Find("ErekiBall2").GetComponent<Animation>().Play();
        yield return new WaitForSecondsRealtime(1);
        cameraPosition = "player1front";
        yield return new WaitForSecondsRealtime(0.5F);
        player1Model.GetComponent<Animator>().Play("elfmage_damage");
        player2Skills.transform.Find("ErekiBall2").GetComponent<ParticleSystem>().Stop();
        Player1HP -= damage;
        if (Player1HP <= 0)
        {
            player1Model.GetComponent<Animator>().Play("elfmage_death");
            gameOverPanel.transform.Find("Text").GetComponent<Text>().text = "Player 2 wins";
            gameOverPanel.SetActive(true);
        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            cameraPosition = "player1";
            playerTurn = "player1";
            NoteText.text = "Choose skill";
            isCastingSkill = false;
        }
    }

    IEnumerator Player2Heal(int value)
    {
        yield return new WaitForSecondsRealtime(2);
        cameraPosition = "player2front";
        player2Skills.transform.Find("GreenCore").GetComponent<ParticleSystem>().Play();
        yield return new WaitForSecondsRealtime(1);
        player2Model.GetComponent<Animator>().Play("elfmage_attack1");

        Player2HP += value;

        yield return new WaitForSecondsRealtime(3);
        player2Skills.transform.Find("GreenCore").GetComponent<ParticleSystem>().Stop();
        cameraPosition = "player1";
        playerTurn = "player1";
        NoteText.text = "Choose skill";
        isCastingSkill = false;
    }
}
