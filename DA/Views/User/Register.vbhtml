@ModelType DA.User
@Code
    ViewData("Title") = "View"
End Code
   
<div class="container">
    <h2 class="mt-5">Register</h2>

    <!-- Display message if exists -->
    <div id="message" class="alert alert-info" style="display: none;">
        <!-- The message will be dynamically inserted here -->
    </div>

    <form action="/User/Register" method="post">
        <div class="form-group">
            <label for="username">Username</label>
            <input type="text" class="form-control" id="username" name="username" required>
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <input type="email" class="form-control" id="email" name="email" required>
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <input type="password" class="form-control" id="password" name="password" required>
        </div>
        <div class="form-group">
            <label for="confirmPassword">Confirm Password</label>
            <input type="password" class="form-control" id="confirmPassword" name="confirmPassword" required>
        </div>
        <button type="submit" class="btn btn-primary">Register</button>
    </form>
</div>

<script>
        // If there's a message, display it
        const message = '@ViewBag.Message';
        if (message) {
            document.getElementById('message').innerText = message;
            document.getElementById('message').style.display = 'block';
        }
</script>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/popperjs/core@2.9.3/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>