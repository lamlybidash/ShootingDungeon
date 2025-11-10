using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Knife : Weapon
{
    protected float time = 0.2f;
    protected Coroutine _rotationKnife = null;
    public override void Shoot(Vector2 dic)
    {
        base.Shoot(dic);
        if (!canAttack)
        {
            return;
        }

        Debug.Log("Chém");
        Thrust(dic);
        EffectDame();
        StartCoroutine(CountTime());
    }

    protected void EffectDame()
    {

    }
    private IEnumerator CountTime()
    {
        canAttack = false;
        InvokeEShoot(timePerShot, currentBullet, magazineCapacity);
        yield return new WaitForSeconds(timePerShot);
        canAttack = true;
    }

    private IEnumerator RotationKnife()
    {
        float speedRotation = 1080f;
        float elapsed = 0f;
        while (!canAttack)
        {
            elapsed += Time.deltaTime;
            float angle = speedRotation * Time.time % 360;
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void Thrust(Vector2 dic)
    {
        if(_rotationKnife!=null)
        {
            StopCoroutine( _rotationKnife );
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        StartCoroutine(ThrustAction(time));
    }

    public IEnumerator ThrustAction(float time)
    {
        // Vị trí ban đầu (local)
        Vector3 start = transform.localPosition;
        Vector3 target = start + new Vector3(1, 0, 0) * rangeBullet;
        float elapsed = 0f;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            // PingPong: 0 -> 1 -> 0 trong suốt time
            float p = Mathf.PingPong(t * 2f, 1f);

            // Lerp từ start -> target -> start
            transform.localPosition = Vector3.Lerp(start, target, p);

            yield return null;
        }
        // Đảm bảo chốt về vị trí gốc
        transform.localPosition = start;
        _rotationKnife = StartCoroutine(RotationKnife());
    }

}
