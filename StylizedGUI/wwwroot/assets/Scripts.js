window.external.receiveMessage(message => alert(message));

//Button event
function SendButtonEvent() {
    window.external.sendMessage('ButtonEvent');
}