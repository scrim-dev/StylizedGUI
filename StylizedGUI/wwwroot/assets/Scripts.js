(async () => {
    await loadStarsPreset(tsParticles);

    await tsParticles.load({
        id: "tsparticles",
        options: {
            preset: "stars",
        },
    });
})();

try {
    tsParticles.load({
        id: "tsparticles",
        options: {
            particles: {
                shape: {
                    type: "square",
                },
            },
            preset: "stars",
        },
    });
} catch { }

window.receiveMessage(message => alert(message));

//Button event
document.getElementById('ButtonTest').addEventListener('click', () => {
    window.sendMessage('Button_Event');
});