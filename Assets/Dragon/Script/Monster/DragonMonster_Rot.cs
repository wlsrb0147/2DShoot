using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DragonMonster_R : MonoBehaviour
{
    Transform pos;
    public float speed = 3;
    public float chaseModeSpeed = 5;
    public float RotDistance = 12;
    public float MaintainDistance = 10;
    public float RotSpeed = 3f;
    public int score;

    public GameObject effect;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        pos = GameObject.FindGameObjectWithTag("DragonPlayer").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pos != null) // �÷��̾ ���� �ʾ��� �� 
        {
            Quaternion angle = Quaternion.identity;
            Vector2 angleVec = new Vector2(pos.position.x - transform.position.x, pos.position.y - transform.position.y);

            if (Vector2.Distance(transform.position, pos.position) < RotDistance )// �� �Ÿ����� ȸ�� ����
            {
                angle.eulerAngles = new Vector3(0, 0, 90 - Mathf.Atan2(angleVec.x, angleVec.y) * Mathf.Rad2Deg);
                transform.rotation = Quaternion.Slerp(transform.rotation, angle, RotSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, pos.position) > MaintainDistance) // �����Ÿ�
                {
                    transform.Translate((speed) * Time.deltaTime, 0, 0); // �ٰ����� �ڵ�
                }
                else
                {
                    transform.Translate((-speed) * Time.deltaTime, 0, 0); // �־����� �ڵ�
                }
                transform.Translate(0, speed * Time.deltaTime, 0); // ȸ���ڵ�
            }
            else  // chasemode �ߵ�
            {
                angle.eulerAngles = new Vector3(0, 0, -Mathf.Atan2(angleVec.x, angleVec.y) * Mathf.Rad2Deg);
                transform.rotation = Quaternion.Slerp(transform.rotation, angle, RotSpeed * Time.deltaTime);
                transform.Translate(0, (chaseModeSpeed) * Time.deltaTime, 0); // �ٰ����� �ڵ�
            }
        }
    }

    private void OnDestroy()
    {
        ScoreSceneText.score[5] += score;
        if (GameObject.FindGameObjectWithTag("DragonLazer") == null)
        {
            DragonGage.gage += 0.02f;
        }

        if (GameObject.FindGameObjectWithTag("DragonPlayer") != null)
        {
            GameObject v = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(v, 0.5f);
        }

    }
}
