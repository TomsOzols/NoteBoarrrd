$(function () {
    $board = $("#Board");
    var boardId = $("#BoardId").val();
    //$.each(notes, function (key, value) {
    //    alert(key + " " + value);
    //    //board.append()
    //})
    var boardHub = $.connection.boardHub;
    $shape = $('#Shape');
    var noteModel = {
        left: 10,
        top: 10
    }

    var notes = null;
    var domNotes = {};

    $.connection.hub.start().done(function () {
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
                    //$shape.draggable({
                    //    drag: PostMovement()
                    //})
                    $('#Note_' + notes[i].Id).draggable({
                        //drag: PostMovement(event, ui)
                        drag: function (event, ui) {
                            var noteId = this.id;
                            var searchId = noteId.split('_');
                            var note = $.grep(notes, function (e) {
                                return e.Id == searchId[searchId.length-1];
                            });
                            note[0].left = ui.position.left;
                            note[0].top = ui.position.top;
                            boardHub.server.moveNote(note[0]);
                        }
                    })
                }
            }
        })
    })

    $.connection.hub.start().done(function () {

    })

    //function PostMovement() {
    //    noteModel = $shape.offset();
    //    boardHub.server.moveNote(noteModel);
    //}

    //function PostMovement(event, ui) {
    //    var searchId = ui.attr('id');
    //    var note = $.grep(notes, function (e) {
    //        return e.Id == searchId;
    //    });
    //    note.left = ui.position.left;
    //    note.right = ui.position.right;
    //    boardHub.server.moveNote(note);
    //}
})