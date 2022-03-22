import React, { useState, useEffect, useCallback } from "react";
import axios from "axios";
import ChannelBar from "../ChannelBar";
import ChatWindow from "../ChatWindow";

const Main = () => {
  const [channels, setChannels] = useState([]); // for ChannelBar
  const [channelMessages, setChannelMessages] = useState([]); // For ChatWindow
  const [channelName, setChannelName] = useState("anime"); // for channelBar

  // grab all channels on load
  useEffect(() => {
    const getChannels = async () => {
      const token = localStorage.getItem("token");
      if (token !== null) {
        await axios
          .get("api/channel/channels", {
            headers: { Authorization: `Bearer ${token}` },
          })
          .then(({ data }) => {
            setChannels(data);
          })
          .catch((err) => console.log(err));
      }
    };
    getChannels();
  }, []);

  // grab all messages from selected pre-selected channel
  useEffect(() => {
    const getChannelMessages = async () => {
      const token = localStorage.getItem("token");
      if (token !== null) {
        await axios
          .get(`api/channel/${channelName}/messages`, {
            headers: { Authorization: `Bearer ${token}` },
          })
          .then(({ data }) => setChannelMessages(data))
          .catch((err) => console.log(err));
      }
    };
    getChannelMessages();
  }, [channelName]);

  // return ChannelBar, ChatWindow, MessageBar
  return (
    <div>
      <div>
        <ChannelBar channels={channels} setChannelName={setChannelName} />
        {/* <DirectMessagesBar /> */}
      </div>

      <div>
        <ChatWindow
          channelName={channelName}
          channelMessages={channelMessages}
          setChannelMessages={setChannelMessages}
        />
      </div>
      <div>{/* <MessagingBar/> */}</div>
    </div>
  );
};

export default Main;
