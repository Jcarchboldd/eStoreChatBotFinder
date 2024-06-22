$(document).ready(function () {
    console.log('Document ready'); // Debugging line

    var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

    connection.on("broadcastMessage", function (user, message) {
        console.log(`Message from ${user}: ${message}`); // Debugging line
        var msg = `<div><strong>${user}:</strong> ${message}</div>`;
        $("#chatMessages").append(msg);
        $("#chatMessages").scrollTop($("#chatMessages")[0].scrollHeight);
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    $('#openChatButton').click(function () {
        console.log('Chat button clicked'); // Debugging line
        $('#chatWindow').toggle();
        if ($('#chatWindow').is(':visible')) {
            $('#openChatButton').text('✖️');
        } else {
            $('#openChatButton').text('💬');
        }
    });

    $('#sendButton').click(function () {
        var user = "User";
        var message = $('#chatInput').val();
        if (message) {
            connection.invoke("SendMessage", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            $('#chatInput').val('').focus();
            $("#chatMessages").scrollTop($("#chatMessages")[0].scrollHeight);
        }
    });

    $('#chatInput').keypress(function (e) {
        if (e.which == 13) {
            $('#sendButton').click();
        }
    });
});