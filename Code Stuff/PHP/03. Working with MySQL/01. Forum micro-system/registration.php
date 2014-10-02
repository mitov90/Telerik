<?php
$title = "Registration";

require "includes/config.php";
require "includes/header.php";

if (isset($_SESSION['is_logged']))
{
    header('Location: message-board.php');
    exit;
}
?>

    <!-- Главно меню -->
    <a href="index.php">Login</a> | <b>New Registration</b><br><br>

    <!-- Форма за регистрация -->
    <form action="registration.php" method="POST">
        <div>Name: <input type="text" name="username" maxlength="20" size="20"/></div>
        <div>Password: <input type="password" name="password" maxlength="20" size="20"/></div>
        <div><input type="submit" value="Sign Up" name="register">
            <input type="reset" value="Clear"></div>
    </form><br>

<?php
if (isset($_POST['register']))
{
    // Нормализация на данните
    $username = strtolower(trim($_POST['username']));
    $password = $_POST['password'];
    $error = FALSE;

    // Валидация на данните
    if (!CheckForValidData($username))
    {
        echo '<div class="error">- You have entered an invalid name!</div>';
        $error = TRUE;
    }

    if (!CheckForValidData($password))
    {
        echo '<div class="error">- You have entered an invalid password!</div>';
        $error = TRUE;
    }

    if (!$error)
    {
        // Извличане на името
        $sql = "SELECT username, password FROM users WHERE username = '" . $username . "'";
        $query = mysqli_query($CONNECTION, $sql);

        if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

        $isExistUser = mysqli_num_rows($query) >= 1 ? TRUE : FALSE; // Връща броя намерени имена

        if ($isExistUser) // Проверка дали съществува потребител с въведеното име
        {
            echo '<div class="error">- Username already exist!</div>';
        }
        else // Добавяме новият потребител към базата данни
        {
            $sql = 'INSERT INTO users (username, password) VALUES ("' . $username . '", "' . $password . '");';
            $query = mysqli_query($CONNECTION, $sql);

            if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

            $_SESSION['is_logged'] = TRUE;
            $_SESSION['username'] = $username;
            header('Location: message-board.php');
            exit;
        }
    }
}
?>

<?php include "includes/footer.php"; ?>