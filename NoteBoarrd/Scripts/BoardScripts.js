$(function () {
    $board = $("#Board");
    var boardId = $("#BoardId").val();
    var boardHub = $.connection.boardHub;
    var notes;

    boardHub.client.moveClientNote = function (noteId, left_, top_) {
        $movedNote = $('#Note_' + noteId);
        $movedNote.css({
            left: left_,
            top: top_
        })
    }

    var messageFrequency = 10;
    var updateRate = 1000;
    var moved = false;

    //Professional
    $("#ChangeToSettings").click(function () {
        $("#ToolSelection").hide();
        $("#BoardSettings").show();
    })

    $("#ChangeToTools").click(function () {
        $("#ToolSelection").show();
        $("#BoardSettings").hide();
    })

    $('#textNote').click(function () {
        $('#newTextNoteDiv').show();
        $('#newPictureNoteDiv').hide();
    })

    $('#pictureNote').click(function () {
        $('#newTextNoteDiv').hide();
        $('#newPictureNoteDiv').show();
    })

    $("#DeleteBoard").click(function () {
        $.ajax({
            url: deleteBoard,
            data: { id: boardId},
            method: 'POST',
            dataType: 'json',
            success: function (data) {
                if (data.success == true) {
                    window.location.href = hubAction + '?message=' + data.message;      //A really bad way of doing this redirect
                }
                else {
                    $("#DeleteBoardError").text(data.message);
                }
            }
        })
    })

    $('#newTextNoteDiv form').submit(function (e) {
        e.preventDefault();
        var form = $(this).serializeArray();
        if (form['NewNote.Text'] == "") {
            var DontDoAnything = 0;         //Please remove this...
        }
        else {
            var boardIdKeyValue = { name: "id", value: boardId }
            form.push(boardIdKeyValue);
            $.ajax({
                url: postNote,
                data: form,
                dataType: 'json',
                method: 'POST',
                success: function (data) {
                    if (data.success) {
                        var element = '<div id="Note_' + data.Id + '" style="left:0px; top:0px; background-color:red; width:50px; height:50px; position:absolute;"><p>' + form[1].value + '</p></div>'; //When the note composition gets changed, then this will break, how sad.
                        $board.append(element);
                        $('#Note_' + data.Id).draggable({
                            containment: parent,
                            drag: function (event, ui) {
                                var noteId = this.id;
                                var searchId = noteId.split('_');
                                var note = $.grep(notes, function (e) {
                                    return e.Id == searchId[searchId.length - 1];
                                });
                                note[0].left = ui.position.left;
                                note[0].top = ui.position.top;
                                moved = true;
                                movedNote = note;
                            }
                        })
                    }
                }
            })
        }
    })

    $('#newPictureNoteDiv form').submit(function (e) {
        e.preventDefault();
        var form = $(this).serializeArray();
    })

    //Working incorrectly
    $board.droppable({
        activeClass: "helperclass",
        hoverClass: "ui-state-hover",
        accept: ".dropTool",
        drop: function (event, ui) {
            $(this).find(".placeholder").remove();
            ui.draggable.clone().css({
                left: xPos,
                top: yPos
            }).appendTo(this);
        }
    })

    var movedNote;

    $.connection.hub.start().done(function () {
        boardHub.server.joinBoard(boardId);
        $.ajax({
            url: getNotes,
            data: { id: boardId },
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                notes = data;
                for (var i = 0; i < notes.length; i++) {
                    var element = '<div id="Note_' + notes[i].Id + '" style="left:' + notes[i].left + 'px; top:' + notes[i].top + 'px; background-color:red; width:50px; height:50px; position:absolute;"><p>' + notes[i].Text + '</p></div>';
                    $board.append(element);
                    $('#Note_' + notes[i].Id).draggable({
                        containment: "parent",
                        drag: function (event, ui) {
                            var noteId = this.id;
                            var searchId = noteId.split('_');
                            var note = $.grep(notes, function (e) {         //Do i even still need this??
                                return e.Id == searchId[searchId.length-1];
                            });
                            note[0].left = ui.position.left;
                            note[0].top = ui.position.top;
                            moved = true;
                            movedNote = note;
                            //boardHub.server.moveNote(boardId, movedNote["Id"], movedNote["left"], movedNote["top"]);
                        }
                    })

                    setInterval(updateNoteOnServer, updateRate)
                }
            }
        })
    })
    


    function updateNoteOnServer() {
        if (moved) {
            boardHub.server.moveNote(boardId, movedNote[0]["Id"], movedNote[0]["left"], movedNote[0]["top"]);
            moved = false;
        }
    }

})