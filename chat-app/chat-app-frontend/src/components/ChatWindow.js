import React from "react";

// Accepts the current channel name as props
// Uses channel name to make api request and render messages from current channel
const ChatWindow = ({ channelMessages }) => {
  return (
    <div>
      {channelMessages.map((message, index) => {
        return (
          <div key={index}>
            {message.username}: {message.text}
          </div>
        );
      })}
    </div>
  );
};

export default ChatWindow;
