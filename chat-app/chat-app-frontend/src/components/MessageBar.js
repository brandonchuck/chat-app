import axios from "axios";
import React, { useState } from "react";

// websocket data flow
// 1. User POSTs newMessage to server
// 2. The SendMessage event will be fired on server
// 3. The SignalR Hub on client side is listening for the SendMessage event and will trigger a re-render inside of useEffect

const MessageBar = ({
  channelName,
  channelMessages,
  setChannelMessages,
  isNewMessage,
  setIsNewMessage,
  hubConnection,
}) => {
  const [newMessage, setNewMessage] = useState("");

  const message = { text: newMessage };

  // create new message in current channel
  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem("token");

    if (token !== null) {
      await axios.post(`api/messages/${channelName}/create`, message, {
        headers: { Authorization: `Bearer ${token}` },
      });
      // setChannelMessages([...channelMessages, newMessage]);
    }

    // this is handling the UI
    hubConnection.on("SendMessage", (message) => {
      setChannelMessages([...channelMessages, message]);
      setIsNewMessage(!isNewMessage); // set isNewMessage to true
    });

    setIsNewMessage(!isNewMessage); // reset isNewMessage to false
    setNewMessage(""); // reset input field
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input
          placeholder="Message..."
          type="text"
          value={newMessage}
          onChange={(e) => setNewMessage(e.target.value)}
        />
        <button type="submit">Send</button>
      </form>
    </div>
  );
};

export default MessageBar;
