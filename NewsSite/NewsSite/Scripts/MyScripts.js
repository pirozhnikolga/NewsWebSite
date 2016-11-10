$(document).ready(function () {
    $('.edit').editable('http://www.example.com/save.php', {
        indicator: 'Saving...',
        tooltip: 'Click to edit...'
    });
});

$('.editable').editable('http://www.example.com/save.php', {
    type: 'textarea',
    cancel: 'Cancel',
    submit: 'OK',
    indicator: 'Saving...',
    tooltip: 'Click to edit...'
});
