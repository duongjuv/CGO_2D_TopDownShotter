using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    private void Start()
    {
        // Ẩn con trỏ chuột khi trò chơi bắt đầu
        Cursor.visible = false;
    }

    private void Update()
    {
        // Lấy vị trí chuột trên màn hình
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Kiểm tra xem con trỏ chuột có nằm trong màn hình trò chơi không
        if (IsMouseInsideGameScreen(mousePosition))
        {
            // Ẩn con trỏ chuột nếu nó nằm trong màn hình trò chơi
            Cursor.visible = false;
        }
        else
        {
            // Hiện con trỏ chuột nếu nó rời khỏi màn hình trò chơi
            Cursor.visible = true;
        }
    }

    private bool IsMouseInsideGameScreen(Vector2 mousePosition)
    {
        // Kích thước màn hình Full HD (1920x1080)
        float screenWidth = 1920f;
        float screenHeight = 1080f;

        // Kiểm tra xem con trỏ chuột có nằm trong màn hình trò chơi không
        return (mousePosition.x >= 0 && mousePosition.x <= screenWidth && mousePosition.y >= 0 && mousePosition.y <= screenHeight);
    }
}
