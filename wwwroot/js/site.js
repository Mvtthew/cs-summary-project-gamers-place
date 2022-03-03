(async () => {
    const gamesListElement = document.getElementById('games-list');

    async function getGamesFromApi() {
        const res = await fetch('/api/gameApi');
        return await res.json();
    }

    async function updateGames() {
        const games = await getGamesFromApi();
        let html = '';

        games.forEach(game => {
            html += `
                <a href="/Home/GameView/${game.gameId}" class="game">
                    <div class="game-cover-image" style="background-image: url('${game.coverImageUrl}')"></div>
                    <div>
                        <h3 class="game-name mb-4 mt-1">${game.name}</h3>
                        <p class="game-genre">🗄 ${game.gameGenre.name}</p>
                        <p class="game-description mb-1">📁 ${game.description}</p>
                        <p class="game-score mb-1">⭐️ ${game.score}</p>
                        <p class="game-year">📅 ${game.yearReleased}</p>
                    </div>
                </a>
            `;
        });

        gamesListElement.innerHTML = html;
    }

    if (gamesListElement) {
        updateGames();
        setInterval(updateGames, 5000);
    }
})();