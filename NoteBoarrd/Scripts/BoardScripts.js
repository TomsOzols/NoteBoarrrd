$(function () {
    $board = $("#Board");
    var boardId = $("#BoardId").val();
    var boardHub = $.connection.boardHub;
    var notes = null;

    boardHub.client.moveClientNote = function (note) {
        $movedNote = $('#Note_' + note.id);
        $movedNote.css({
            left: note.left,
            top: note.top
        })
    }

    var xPos;
    var yPos;

    $("#textNote").draggable({
        appendTo: "body",
        helper: "clone",
        stop: function(){
            var offset = $(this).offset();
            xPos = offset.left;
            yPos = offset.top;
        }
    })

    $board.droppable({
        activeClass: "helperclass",
        hoverClass: "ui-state-hover",
        accept: ".dropTool",
        drop: function (event, ui) {
            $(this).find(".placeholder").remove();
            //var newNote = $("<div></div>");
            //newNote.css({
            //    left: xPos,
            //    top: yPos
            //})
            //newNote.html(ui.draggable).appendTo(this);
            //ui.draggable.css({
            //    left: xPos,
            //    top: yPos
            //})
            ui.draggable.clone().css({
                left: xPos,
                top: yPos
            }).appendTo(this);
        }
    })

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
                    var element = '<div id="Note_' + notes[i].Id + '" style="left:' + notes[i].left + 'px; top:' + notes[i].top + 'px; background-color:red; width:50px; height:50px;"></div>';
                    $board.append(element);
                    $('#Note_' + notes[i].Id).draggable({
                        drag: function (event, ui) {
                            var noteId = this.id;
                            var searchId = noteId.split('_');
                            var note = $.grep(notes, function (e) {
                                return e.Id == searchId[searchId.length-1];
                            });
                            note[0].left = ui.position.left;
                            note[0].top = ui.position.top;
                            boardHub.server.moveNote(note[0], boardId);
                        }
                    })
                }
            }
        })
    })

})