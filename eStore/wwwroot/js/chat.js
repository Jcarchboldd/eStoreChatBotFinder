$(document).ready(function () {
    console.log('Document ready'); // Debugging line

    var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

    connection.on("broadcastMessage", function (user, message, listProducts) {
        console.log(`Message from ${user}: ${message}`); // Debugging line
        console.log(listProducts); // Debugging line
        var msg = `<div><strong>${user}:</strong> ${message}</div>`;
        $("#chatMessages").append(msg);
        $("#chatMessages").scrollTop($("#chatMessages")[0].scrollHeight);
        if (listProducts) {
            console.log(loadPageUrl); // Debugging line  
            var pageNumber = 1; 
            $.ajax({
                url: loadPageUrl,
                type: 'GET',
                data: { productPage: pageNumber, listProducts: listProducts },
                success: function (result) {
                    $('#productListContainer').html(result);
                }
            });
        }
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