let currentUser = 'Usuário 1';

function startChat(user) {
  currentUser = user;
  document.getElementById('chatBox').style.display = 'flex';
  document.getElementById('messages').innerHTML = `<p>Iniciando chat com ${user}...</p>`;
}

function sendMessage(event) {
  if (event.key === 'Enter' || event.type === 'click') {
    const message = document.getElementById('messageInput').value;
    if (message.trim()) {
      const newMessage = `<div class="message sent"><span>Você: </span>${message}</div>`;
      document.getElementById('messages').innerHTML += newMessage;
      document.getElementById('messageInput').value = '';
      scrollToBottom();
    }
  }
}

function scrollToBottom() {
  const messages = document.getElementById('messages');
  messages.scrollTop = messages.scrollHeight;
}

function searchUser() {
  const query = document.getElementById('searchInput').value.toLowerCase();
  const users = document.querySelectorAll('.user');
  users.forEach(user => {
    const name = user.innerText.toLowerCase();
    if (name.includes(query)) {
      user.style.display = 'flex';
    } else {
      user.style.display = 'none';
    }
  });
}
