using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    Rigidbody rb; // �÷��̾��� Rigidbody ������Ʈ

    private float upSpeed = 7f; // �÷��̾��� ���� �ӵ�

    [SerializeField]
    private GameObject clearUI; // Ŭ���� UI
    [SerializeField]
    private GameObject failedUI; // ���� ���� UI

    [SerializeField]
    private AudioSource portalAudio; // ��Ż�� �� �� ����
    [SerializeField]
    private AudioSource jumpAudio; // ���� ����� ����� ���� ����
    [SerializeField]
    private AudioSource trapAudio; // Ʈ���� ����� ���� ����
    [SerializeField]
    private AudioSource deleteAudio; // �Ͼ� ����� ����� ���� ����

    public int stageLevel; // �������� ����
    public int stageDetailLevel; // ���������� ���� ����

    static public bool isCleared = false; // ���������� Ŭ���� ����
    static public bool isfailed = false; // ���������� ���� ����

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ����̳� �������� ���� �̺�Ʈ
        if(other.gameObject.CompareTag("TRAPWALL") || other.gameObject.CompareTag("FALLGROUND"))
        {
            isfailed = true; // ���� ���� ����

            failedUI.SetActive(true); // ���� ���� UI Ȱ��ȭ

            Time.timeScale = 0; // ���� �Ͻ� ����
        }

        // �÷��̾ ��Ż�� ����� ��
        if(other.gameObject.CompareTag("PORTAL"))
        {
            clearUI.SetActive(true); // ���� Ŭ���� UI ����
            isCleared = true; // ���� Ŭ����

            Time.timeScale = 0; // �Ͻ� ����

            portalAudio.Play(); // ���� ���
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ �Ķ� ��ϰ� ����� ���
        if(collision.gameObject.CompareTag("UPWALL"))
        {
            rb.AddForce(upSpeed * Vector3.up, ForceMode.Impulse); // �÷��̾� ����

            jumpAudio.Play(); // ���� ���
        }

        // �÷��̾ �Ͼ� ����� ����� ���
        if(collision.gameObject.CompareTag("DELETEWALL"))
        {
            StartCoroutine(DeleteSound());
        }
    }

    IEnumerator DeleteSound()
    {
        yield return new WaitForSeconds(1f);

        deleteAudio.Play(); // ���� ���
    }
}
