using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость движения
    public float sensitivityX = 10f;  // Чувствительность вращения по оси X
    public float sensitivityY = 10f;  // Чувствительность вращения по оси Y
    public float minimumY = -90f;  // Минимальный угол вращения по оси Y
    public float maximumY = 90f;    // Максимальный угол вращения по оси Y

    private float rotationY = 0f;

    void Update()
    {
        // Обработка ввода для движения
        MovePlayer();

        // Обработка ввода для вращения камеры только при зажатой ЛКМ
        if (Input.GetMouseButton(1)) // 0 - это ЛКМ
        {
            RotateCamera();
        }
    }

    private void MovePlayer()
    {
        // Получаем ввод с клавиатуры
        float horizontal = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float vertical = Input.GetAxis("Vertical");     // W/S или стрелки вверх/вниз

        // Создаем вектор движения
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Перемещаем игрока
        if (direction.magnitude >= 0.1f)
        {
            // Переводим направление в мировые координаты
            Vector3 moveDirection = transform.TransformDirection(direction);
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void RotateCamera()
    {
        // Получаем ввод мыши
        float deltaX = Input.GetAxis("Mouse X") * sensitivityX;
        float deltaY = Input.GetAxis("Mouse Y") * sensitivityY;

        // Обрабатываем вращение по вертикали
        rotationY -= deltaY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        // Применяем вращение к камере
        transform.localRotation = Quaternion.Euler(rotationY, transform.localEulerAngles.y + deltaX, 0);
    }
}