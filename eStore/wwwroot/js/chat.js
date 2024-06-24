$(document).ready(function () {
    // Generate a unique session ID
    function generateUUID() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    var sessionId = generateUUID();
    console.log('Session ID:', sessionId); // Debugging line

    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub?sessionId=" + sessionId)
        .build();

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
        $('#chatWindow').toggle();
        if ($('#chatWindow').is(':visible')) {
            $('#openChatButton').text('✖️');
        } else {
            $('#openChatButton').text('💬');
        }
    });

    $('#closeChatButton').click(function () {
        $('#chatWindow').hide();
        $('#openChatButton').text('💬');
    });

    $('#sendButton').click(function () {    
        var user = "User";
        var message = $('#chatInput').val();
        if (message) {
            connection.invoke("SendMessage",sessionId, user, message).catch(function (err) {
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