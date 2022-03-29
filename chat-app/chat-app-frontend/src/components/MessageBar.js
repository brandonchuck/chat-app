import axios from "axios";
import React, { useState } from "react";

const MessageBar = ({
  channelName,
  channelMessages,
  setChannelMessages,
  isNewMessage,
  setIsNewMessage,
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
      setChannelMessages([...channelMessages, newMessage]);
      setIsNewMessage(!isNewMessage);
    }
    setIsNewMessage(!isNewMessage);
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
